namespace Sis.Framework.Routes
{
    using Http.Requests.Contracts;
    using Http.Responses.Contracts;
    using Sis.Http.Enums;
    using Sis.Http.Responses;
    using Sis.WebServer.Results;
    using System.IO;
    using WebServer.Api.Contracts;

    public class ResourceRouter : IHttpHeandler
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            var httpRequestPath = request.Path;
            var indexOfStartOfExtension = httpRequestPath.LastIndexOf('.');
            var indexOfStartOfNameOfResource = httpRequestPath.LastIndexOf('/');

            var requestPathExtension = httpRequestPath.Substring(indexOfStartOfExtension);

            var resourceName = httpRequestPath.Substring(indexOfStartOfNameOfResource);

            var resourcePath = MvcContext.Get.RootDirectoryRelativePath
                              + $"/{MvcContext.Get.ResourceFolderName}"
                              + $"/{requestPathExtension.Substring(1)}"
                              + resourceName;

            if (!File.Exists(resourcePath))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            var fileContent = File.ReadAllBytes(resourcePath);

            return new InlineResourceResult(fileContent, HttpResponseStatusCode.OK);
        }
    }
}
