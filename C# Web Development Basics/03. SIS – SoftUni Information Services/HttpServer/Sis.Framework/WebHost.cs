using Sis.Framework.Api;
using Sis.Framework.Routes;
using Sis.Framework.Services;
using Sis.WebServer;
using Sis.WebServer.Api.Contracts;
using Sis.WebServer.Routing;

namespace Sis.Framework
{
    public static class WebHost
    {
        private const int Port = 8000;

        public static void Start(IMvcApplication application)
        {
            IDependencyContainer container = new DependencyContainer();

            application.ConfigureServices(container);

            var httpRouteHandling = new HttpRouteHandlingContext(new ControllerRouter(container), new ResourceRouter());

            application.Configure();

            Server server = new Server(Port, httpRouteHandling);

            server.Run();
        }
    }
}
