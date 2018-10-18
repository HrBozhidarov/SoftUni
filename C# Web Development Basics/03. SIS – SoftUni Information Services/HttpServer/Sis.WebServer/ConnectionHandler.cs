namespace Sis.WebServer
{
    using Api.Contracts;
    using Http.Enums;
    using Http.Exceptions;
    using Http.Headers;
    using Http.Requests;
    using Http.Requests.Contracts;
    using Http.Responses.Contracts;
    using Http.Sessions;
    using Results;
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class ConnectionHandler
    {
        private readonly Socket client;
        private readonly IHttpHandlingContext handlersContext;

        public ConnectionHandler(Socket client, IHttpHandlingContext handlersContext)
        {
            this.client = client;
            this.handlersContext = handlersContext;
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
            try
            {
                var httpRequest = await this.ReadRequestAsync();

                if (httpRequest != null)
                {
                    var sessionId = this.SetRequestSession(httpRequest);

                    var httpResponse = this.handlersContext.Handle(httpRequest);

                    if (sessionId != null)
                    {
                        httpResponse.Headers.Add(new HttpHeader("Set-Cookie", $"{HttpSessionStorage.SessionCookieKey}={sessionId}; HttpOnly; path=/"));
                    }

                    await this.PrepareaResponse(httpResponse);
                }
            }
            catch (BadRequestException e)
            {
                await this.PrepareaResponse(new TextResult(e.Message, HttpResponseStatusCode.BadRequest));
            }
            catch (Exception e)
            {
                await this.PrepareaResponse(new TextResult(e.Message, HttpResponseStatusCode.InternalServerError));
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