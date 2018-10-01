namespace Sis.WebServer.Results
{
    using Http.Responses;
    using Sis.Http.Enums;
    using Sis.Http.Headers;
    using System.Text;

    public class HtmlResult : HttpResponse
    {
        public HtmlResult(string content, HttpResponseStatusCode statusCode)
            :base(statusCode)
        {
            this.Headers.Add(new HttpHeader("Content-Type", "text/html"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
