namespace StoreAlbum.App
{
    using Microsoft.EntityFrameworkCore;
    using Sis.WebServer;
    using Sis.WebServer.Routing;
    using StoreAlbum.App.Data;

    class Luncher
    {
        static void Main(string[] args)
        {
            var db = new StoreAlbumContext();
            //db.Database.EnsureDeleted();
            db.Database.Migrate();

            var serverRoutingTable = new Route(new ServerRoutingTable()).InitializeRoute();

            var server = new Server(8000, serverRoutingTable);

            server.Run();
        }
    }
}
