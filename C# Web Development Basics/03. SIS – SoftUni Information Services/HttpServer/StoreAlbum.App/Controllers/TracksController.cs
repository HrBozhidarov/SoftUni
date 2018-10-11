namespace StoreAlbum.App.Controllers
{
    using Services;
    using Services.Contracts;
    using Sis.Http.Requests.Contracts;
    using Sis.Http.Responses.Contracts;
    using Sis.WebServer.Results;
    using System;

    public class TracksController : BaseController
    {
        private readonly ITrackService trackService;

        public TracksController()
        {
            this.trackService = new TrackService();
        }

        public IHttpResponse Create(IHttpRequest httpRequest)
        {
            if (!this.IfUserIsLogin(httpRequest))
            {
                return new RedirectResult("/home/login");
            }

            var albumId = httpRequest.QueryData["id"].ToString();

            this.viewData["albumId"] = albumId;

            return View("Create");
        }

        public IHttpResponse CreatePost(IHttpRequest httpRequest)
        {
            var albumId = httpRequest.QueryData["id"].ToString();
            var id = Guid.NewGuid().ToString();
            var name = httpRequest.FormData["Name"].ToString();
            var link = httpRequest.FormData["Link"].ToString();
            var price = decimal.Parse(httpRequest.FormData["Price"].ToString());

            this.trackService.Create(albumId, id, name, link, price);

            return new RedirectResult($"/albums/details?id={albumId}");
        }

        public IHttpResponse Details(IHttpRequest httpRequest)
        {
            if (!this.IfUserIsLogin(httpRequest))
            {
                return new RedirectResult("/home/login");
            }

            var albumId = httpRequest.QueryData["albumId"].ToString();
            var trackId = httpRequest.QueryData["trackId"].ToString();

            var track = this.trackService.GetById(trackId);

            this.viewData["srcFrame"] = track.Link.Replace("https://www.youtube.com/watch?v=", $"//www.youtube.com/embed/");
            this.viewData["nameTrack"] = track.Name;
            this.viewData["priceTrack"] = track.Price.ToString();
            this.viewData["albumId"] = albumId;

            ////www.youtube.com/embed/C8kSrkz8Hz8

            return View("Details");
        }
    }
}
