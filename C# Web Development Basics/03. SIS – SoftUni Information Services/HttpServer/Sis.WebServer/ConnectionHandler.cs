namespace Sis.WebServer
{
    using Routing;
    using Http.Requests;
    using Http.Requests.Contracts;
    using Http.Responses.Contracts;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using System.Text;
    using System;
    using Sis.Http.Responses;
    using Sis.Http.Enums;

    public class ConnectionHandler
    {
        private readonly Socket client;
        private readonly ServerRoutingTable serverRoutingTable;

        public ConnectionHandler(Socket client, ServerRoutingTable serverRoutingTable)
        {
            this.client = client;
            this.serverRoutingTable = serverRoutingTable;
        }

        private IHttpRequest ReadRequest()
        {
            var result = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int numberOfBytesRead = this.client.Receive(data.Array, SocketFlags.None);

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
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            return this.serverRoutingTable.Routes[httpRequest.RequestMethod][httpRequest.Path].Invoke(httpRequest);
        }

        private async Task PrepareaResponse(IHttpResponse httpResponse)
        {
            var byteSegments = httpResponse.GetBytes();

            Console.WriteLine();
            Console.WriteLine("----Response----");
            Console.WriteLine(Encoding.UTF8.GetString(byteSegments));

            this.client.Send(byteSegments, SocketFlags.None);
        }

        public async Task ProcessRequestAsync()
        {
            var httpRequest = this.ReadRequest();

            if (httpRequest != null)
            {
                var httpResponse = this.HandleRequest(httpRequest);

                await this.PrepareaResponse(httpResponse);
            }

            this.client.Shutdown(SocketShutdown.Both);
        }
    }
}
