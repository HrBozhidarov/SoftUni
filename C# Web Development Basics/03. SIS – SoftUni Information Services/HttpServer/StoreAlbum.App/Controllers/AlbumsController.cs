namespace StoreAlbum.App.Controllers
{
    using Services;
    using Services.Contracts;
    using Sis.Http.Requests.Contracts;
    using Sis.Http.Responses.Contracts;
    using Sis.WebServer.Results;
    using System;
    using System.Linq;
    using System.Net;

    public class AlbumsController : BaseController
    {
        private readonly IAlbumService albumService;
        private readonly ITrackService trackService;

        public AlbumsController()
        {
            this.albumService = new AlbumService();
            this.trackService = new TrackService();
        }

        public IHttpResponse Create(IHttpRequest httpRequest)
        {
            if (!this.IfUserIsLogin(httpRequest))
            {
                return new RedirectResult("/home/login");
            }

            return this.View("Create");
        }

        public IHttpResponse CreatePost(IHttpRequest httpRequest)
        {
            if (httpRequest.FormData.Any(x => string.IsNullOrEmpty(x.Value as string)))
            {
                return new RedirectResult("/albums/create");
            }

            var id = Guid.NewGuid().ToString();
            var name = httpRequest.FormData["Name"].ToString();
            var cover = WebUtility.UrlDecode(httpRequest.FormData["Cover"].ToString());

            this.albumService.Create(id, name, cover);

            return new RedirectResult("/albums/all");
        }


        public IHttpResponse All(IHttpRequest httpRequest)
        {
            if (!this.IfUserIsLogin(httpRequest))
            {
                return new RedirectResult("/home/login");
            }

            var allAlbums = this.albumService.GetAllAlbums();

            var htmlAlbums = "";

            foreach (var album in allAlbums)
            {
                htmlAlbums += $@"<p>
                                 <a href=/albums/details?id={album.Id}>{album.Name}</a>
                                 </p>";
            }

            this.viewData["allAlbums"] = htmlAlbums;

            return this.View("All");
        }

        public IHttpResponse Details(IHttpRequest httpRequest)
        {
            if (!this.IfUserIsLogin(httpRequest))
            {
                return new RedirectResult("/home/login");
            }

            var id = httpRequest.QueryData["id"].ToString();

            var album = this.albumService.GetAlbumById(id);

            this.viewData["tracksHave"] = "none";
            this.viewData["noTracks"] = "block";

            if (album.Tracks.Any())
            {
                this.viewData["tracksHave"] = "block";
                this.viewData["noTracks"] = "none";
            }

            var price = 0m;
            var tracks = string.Empty;
            int count = 1;

            foreach (var trackId in album.Tracks.Select(x => x.TrackId))
            {
                var track = this.trackService.GetById(trackId);
                price += track.Price;
                tracks += $"<li>{count}. <a href=\"/tracks/details?albumId={album.Id}&trackId={track.Id}\">{track.Name}</a></li>" + Environment.NewLine;

                count++;
            }

            this.viewData["albumId"] = album.Id;
            this.viewData["imgUrl"] = album.Cover;
            this.viewData["albumName"] = album.Name;
            this.viewData["price"] = price.ToString();
            this.viewData["tracks"] = tracks;

            return View("Details");
        }
    }
}