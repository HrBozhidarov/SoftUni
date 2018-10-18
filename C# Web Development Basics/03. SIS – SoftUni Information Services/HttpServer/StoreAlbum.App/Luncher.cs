namespace StoreAlbum.App
{
    using Microsoft.EntityFrameworkCore;
    using Sis.Framework.Routes;
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

            var handlingContext = new HttpRouteHandlingContext(new ControllerRouter(), new ResourceRouter());
            var server = new Server(8000, handlingContext);

            server.Run();
        }
    }
}