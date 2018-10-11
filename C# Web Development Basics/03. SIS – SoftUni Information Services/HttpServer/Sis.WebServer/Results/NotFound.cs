namespace Sis.WebServer.Results
{
    using Http.Enums;
    using Http.Responses;
    using Sis.Http.Headers;
    using System.Text;

    public class NotFound : HttpResponse
    {
        public NotFound(HttpResponseStatusCode statusCode, string errorMesage = "Not Found 404")
            : base(statusCode)
        {
            this.Headers.Add(new HttpHeader("Content-Type", "text/html"));
            this.Content = Encoding.UTF8.GetBytes(errorMesage);
        }
    }
}
