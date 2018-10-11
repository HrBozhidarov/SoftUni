namespace StoreAlbum.App
{
    using Controllers;
    using Sis.Http.Enums;
    using Sis.WebServer.Results;
    using Sis.WebServer.Routing;

    public class Route
    {
        private readonly ServerRoutingTable serverRoutingTable;

        public Route(ServerRoutingTable serverRoutingTable)
        {
            this.serverRoutingTable = serverRoutingTable;
        }

        public ServerRoutingTable InitializeRoute()
        {
            this.serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] =
                request => new HomeController().Index(request);

            this.serverRoutingTable.Routes[HttpRequestMethod.Get]["/home/index"] =
                request => new RedirectResult("/");

            this.serverRoutingTable.Routes[HttpRequestMethod.Get]["/home/register"] =
                request => new UsersController().Register(request);

            this.serverRoutingTable.Routes[HttpRequestMethod.Post]["/home/login"] =
                request => new UsersController().LoginPost(request);

            this.serverRoutingTable.Routes[HttpRequestMethod.Get]["/home/login"] =
                request => new UsersController().Login(request);

            this.serverRoutingTable.Routes[HttpRequestMethod.Get]["/home/logout"] =
                request => new UsersController().Logout(request);

            this.serverRoutingTable.Routes[HttpRequestMethod.Post]["/users/register"] =
               request => new UsersController().RegisterPost(request);

            this.serverRoutingTable.Routes[HttpRequestMethod.Get]["/albums/all"] =
               request => new AlbumsController().All(request);

            this.serverRoutingTable.Routes[HttpRequestMethod.Get]["/albums/create"] =
              request => new AlbumsController().Create(request);

            this.serverRoutingTable.Routes[HttpRequestMethod.Post]["/albums/create"] =
             request => new AlbumsController().CreatePost(request);

            this.serverRoutingTable.Routes[HttpRequestMethod.Get]["/albums/details"] =
             request => new AlbumsController().Details(request);

            this.serverRoutingTable.Routes[HttpRequestMethod.Get]["/tracks/create"] =
                request => new TracksController().Create(request);

            this.serverRoutingTable.Routes[HttpRequestMethod.Post]["/tracks/create"] =
               request => new TracksController().CreatePost(request);

            this.serverRoutingTable.Routes[HttpRequestMethod.Get]["/tracks/details"] =
               request => new TracksController().Details(request);

            return this.serverRoutingTable;
        }
    }
}