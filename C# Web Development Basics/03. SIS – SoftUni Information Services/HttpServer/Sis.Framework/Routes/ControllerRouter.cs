namespace Sis.Framework.Routes
{
    using Attributes;
    using Controllers;
    using Http.Enums;
    using Http.Exstensions;
    using Http.Requests.Contracts;
    using Http.Responses.Contracts;
    using Services;
    using Sis.Framework.Attributes.Action;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using WebServer.Api.Contracts;
    using WebServer.Results;

    public class ControllerRouter : IHttpHeandler
    {
        private readonly IDependencyContainer dependencyContainer;

        public ControllerRouter(IDependencyContainer dependencyContainer)
        {
            this.dependencyContainer = dependencyContainer;
        }

        private Controller GetController(string controllerName, IHttpRequest request)
        {
            if (!string.IsNullOrEmpty(controllerName))
            {
                var pathController = string.Format("{0}.{1}.{2}, {0}",
                                                    MvcContext.Get.AssemblyName,
                                                    MvcContext.Get.ControllersFolder,
                                                    controllerName.Capitalize() + MvcContext.Get.ControllersSuffix);

                var controllerType = Type.GetType(pathController);

                var controller = (Controller)this.dependencyContainer.CreateInstance(controllerType);

                if (controller != null)
                {
                    controller.Request = request;
                }

                return controller;
            }

            return null;
        }

        private MethodInfo GetMethod(string requestMethod, Controller controller, string actionName)
        {
            var a = GetSuitableMethods(controller, actionName);

            foreach (var methodInfo in GetSuitableMethods(controller, actionName))
            {
                var attributes = methodInfo.GetCustomAttributes()
                    .Where(x => x is HttpMehtodAttribute)
                    .Cast<HttpMehtodAttribute>();

                if (!attributes.Any() && requestMethod.ToUpper() == "GET")
                {
                    return methodInfo;
                }

                foreach (var attribute in attributes)
                {
                    if (attribute.IsValid(requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return null;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
        {
            if (controller == null)
            {
                return new MethodInfo[0];
            }

            var a = controller.GetType().GetMethods().Where(x => x.Name.ToUpper() == actionName.ToUpper());


            foreach (var item in controller.GetType().GetMethods())
            {
                Console.WriteLine(item.Name);
            }

            return controller.GetType().GetMethods().Where(x => x.Name.ToUpper() == actionName.ToUpper());
        }

        private IHttpResponse PrepareResponse(ActionResults.Contracts.IActionResult actionResult)
        {
            var invocationResult = actionResult.Invoke();

            if (actionResult is ActionResults.Contracts.IViewable)
            {
                return new HtmlResult(invocationResult, HttpResponseStatusCode.OK);
            }
            else if (actionResult is ActionResults.Contracts.IRedirectable)
            {
                return new RedirectResult(invocationResult);
            }

            throw new InvalidOperationException("The view result is not supported");
        }

        public IHttpResponse Handle(IHttpRequest httpRequest)
        {
            var controllerName = string.Empty;
            var actionName = string.Empty;

            if (httpRequest.Url == "/")
            {
                controllerName = "Home";
                actionName = "Index";
            }

            var urlSplit = httpRequest.Url.Split("/", StringSplitOptions.RemoveEmptyEntries);

            var requestMethod = httpRequest.RequestMethod.ToString();

            if (urlSplit.Length == 2)
            {
                controllerName = urlSplit[0];
                actionName = urlSplit[1];
            }

            var controller = this.GetController(controllerName, httpRequest);
            var method = this.GetMethod(requestMethod, controller, actionName);

            object[] actionParameters = this.MapActionParameters(method, httpRequest, controller);

            ActionResults.Contracts.IActionResult actionResult = this.InvokeAction(controller, method, actionParameters);

            return this.Authorize(controller, method) ?? PrepareResponse(actionResult);
        }

        private ActionResults.Contracts.IActionResult InvokeAction(Controller controller, MethodInfo method, object[] actionParameters)
        {
            return (ActionResults.Contracts.IActionResult)method.Invoke(controller, actionParameters);
        }

        private object[] MapActionParameters(MethodInfo method, IHttpRequest httpRequest, Controller controller)
        {
            var parameters = method.GetParameters();

            var parameterObjects = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var currentParameterInfo = parameters[i];

                if (currentParameterInfo.GetType().IsValueType || currentParameterInfo.ParameterType == typeof(string))
                {
                    parameterObjects[i] = ProccessPrimitiveParameters(currentParameterInfo, httpRequest);
                }
                else
                {
                    var bindingModel = ProccessBindingModelParameter(currentParameterInfo, httpRequest);

                    controller.ModelState.IsValid = this.IsValidModel(bindingModel);

                    parameterObjects[i] = bindingModel;
                }
            }

            return parameterObjects;
        }

        private bool? IsValidModel(object bindingModel)
        {
            var type = bindingModel.GetType();
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var validationAttributes = property.GetCustomAttributes().Where(x => x is ValidationAttribute)
                 .Cast<ValidationAttribute>().ToArray();

                foreach (var attr in validationAttributes)
                {
                    var value = type.GetProperty(property.Name).GetValue(bindingModel, null);

                    if (!attr.IsValid(value))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private object ProccessBindingModelParameter(ParameterInfo currentParameterInfo, IHttpRequest httpRequest)
        {
            var bindingModelType = currentParameterInfo.ParameterType;
            var instanceModelType = Activator.CreateInstance(bindingModelType);
            var bindingModelProperties = bindingModelType.GetProperties();

            foreach (var property in bindingModelProperties)
            {
                try
                {
                    object value = this.GetParameterFormRequestData(httpRequest, property.Name);
                    property.SetValue(instanceModelType, Convert.ChangeType(value, property.PropertyType));
                }
                catch
                {
                    Console.WriteLine($"The {property.Name} can not be mapped.");
                }
            }

            return Convert.ChangeType(instanceModelType, bindingModelType);
        }

        private object ProccessPrimitiveParameters(ParameterInfo param, IHttpRequest httpRequest)
        {
            object value = this.GetParameterFormRequestData(httpRequest, param.Name);
            return Convert.ChangeType(value, param.ParameterType);
        }

        private object GetParameterFormRequestData(IHttpRequest httpRequest, string paramName)
        {
            if (httpRequest.QueryData.ContainsKey(paramName))
            {
                return httpRequest.QueryData[paramName];
            }
            else if (httpRequest.FormData.ContainsKey(paramName))
            {
                return httpRequest.FormData[paramName];
            }

            return null;
        }

        private IHttpResponse Authorize(Controller controller, MethodInfo action)
        {
            if (action.GetCustomAttributes()
                .Where(x => x is AuthorizeAttribute)
                .Cast<AuthorizeAttribute>()
                .Any(x => !x.IsAuthorized(controller.Identity)))
            {
                return new UnAuthorizedResult();
            }

            return null;
        }
    }
}
