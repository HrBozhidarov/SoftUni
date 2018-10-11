namespace Sis.WebServer
{
    using Common;
    using Routing;
    using Http.Enums;
    using Http.Headers;
    using Http.Requests;
    using Http.Requests.Contracts;
    using Http.Responses.Contracts;
    using Http.Sessions;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using System.Text;
    using System;
    using WebServer.Results;
    using System.IO;

    public class ConnectionHandler
    {
        private readonly Socket client;
        private readonly ServerRoutingTable serverRoutingTable;

        public ConnectionHandler(Socket client, ServerRoutingTable serverRoutingTable)
        {
            this.client = client;
            this.serverRoutingTable = serverRoutingTable;
        }

        private async Task<IHttpRequest> ReadRequestAsync()
        {
            var result = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                var numberOfBytesRead = await this.client.ReceiveAsync(data.Array, SocketFlags.None);

                if (numberOfBytesRead == 0)
                {
                    break;
                }

                var byteAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesRead);
                result.Append(byteAsString);

                if (numberOfBytesRead < 1023)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }

            Console.WriteLine();
            Console.WriteLine("----Request----");
            Console.WriteLine(result.ToString().Trim());

            return new HttpRequest(result.ToString());
        }

        private IHttpResponse HandleRequest(IHttpRequest httpRequest)
        {
            if (!this.serverRoutingTable.Routes.ContainsKey(httpRequest.RequestMethod)
                || !this.serverRoutingTable.Routes[httpRequest.RequestMethod].ContainsKey(httpRequest.Path))
            {
                return this.ReturnIfResource(httpRequest.Path);
            }

            return this.serverRoutingTable.Routes[httpRequest.RequestMethod][httpRequest.Path].Invoke(httpRequest);
        }

        private IHttpResponse ReturnIfResource(string path)
        {
            var splitPathOnThePart = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            //if (splitPathOnThePart[0] == "favicon.ico")
            //{
            //    splitPathOnThePart[0] = "Resources/favicon.ico";
            //}

            var pathToFile = ConstantsApp.DefaultResourcesPath + string.Join("/", splitPathOnThePart);

            try
            {
                var resource = File.ReadAllText(pathToFile);

                byte[] bytes = Encoding.UTF8.GetBytes(resource);

                return new InlineResourceResult(bytes, HttpResponseStatusCode.OK);
            }
            catch 
            {
                return new NotFound(HttpResponseStatusCode.NotFound);
            }
        }

        private async Task PrepareaResponse(IHttpResponse httpResponse)
        {
            var byteSegments = httpResponse.GetBytes();

            Console.WriteLine();
            Console.WriteLine("----Response----");
            Console.WriteLine(Encoding.UTF8.GetString(byteSegments));

            await this.client.SendAsync(byteSegments, SocketFlags.None);
        }

        public async Task ProcessRequestAsync()
        {
            var httpRequest = await this.ReadRequestAsync();

            if (httpRequest != null)
            {
                var sessionId = this.SetRequestSession(httpRequest);

                //here problem
                var httpResponse = this.HandleRequest(httpRequest);

                if (sessionId != null)
                {
                    httpResponse.Headers.Add(new HttpHeader("Set-Cookie", $"{HttpSessionStorage.SessionCookieKey}={sessionId}; HttpOnly; path=/"));
                }

                await this.PrepareaResponse(httpResponse);
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private string SetRequestSession(IHttpRequest httpRequest)
        {
            string sessionId = null;

            if (httpRequest.Cookies.ContainsCookie(HttpSessionStorage.SessionCookieKey))
            {
                var cookie = httpRequest.Cookies.GetCookie(HttpSessionStorage.SessionCookieKey);
                var cookieValue = cookie.Value;

                httpRequest.Session = HttpSessionStorage.GetSession(cookieValue);
            }
            else
            {
                sessionId = Guid.NewGuid().ToString();

                httpRequest.Session = HttpSessionStorage.GetSession(sessionId);
            }

            return sessionId;
        }
    }
}