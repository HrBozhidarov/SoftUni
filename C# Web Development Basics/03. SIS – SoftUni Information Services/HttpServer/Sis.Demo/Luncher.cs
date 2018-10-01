namespace Sis.Demo
{
    using Http.Enums;
    using WebServer;
    using WebServer.Routing;

    class Luncher
    {
        static void Main(string[] args)
        {
            var serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new HomeController().Index();

            var server = new Server(8000, serverRoutingTable);

            server.Run();
        }
    }
}
