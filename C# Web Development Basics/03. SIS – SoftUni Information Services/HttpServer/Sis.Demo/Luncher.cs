namespace Sis.Demo
{
    using Framework.Routes;
    using Sis.WebServer.Routing;
    using WebServer;

    class Luncher
    {
        static void Main(string[] args)
        {
            var handlingContext = new HttpRouteHandlingContext(new ControllerRouter(), new ResourceRouter());

            var server = new Server(8000, handlingContext);

            server.Run();
        }
    }
}
