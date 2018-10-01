namespace Sis.WebServer.Routing
{
    using Http.Enums;
    using Http.Requests.Contracts;
    using Http.Responses.Contracts;
    using System;
    using System.Collections.Generic;

    public class ServerRoutingTable
    {
        public ServerRoutingTable()
        {

            this.Routes = new Dictionary<HttpRequestMethod, IDictionary<string, Func<IHttpRequest, IHttpResponse>>>();

            this.Routes[HttpRequestMethod.Get] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>();
            this.Routes[HttpRequestMethod.Post] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>();
            this.Routes[HttpRequestMethod.Put] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>();
            this.Routes[HttpRequestMethod.Delete] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>();
        }

        public IDictionary<HttpRequestMethod, IDictionary<string, Func<IHttpRequest, IHttpResponse>>> Routes { get; }
    }
}
