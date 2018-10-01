namespace Sis.WebServer.Results
{
    using Http.Enums;
    using Http.Headers;
    using Http.Responses;
    using System.Text;

    public class TextResult : HttpResponse
    {
        public TextResult(string content, HttpResponseStatusCode statusCode)
            :base(statusCode)
        {
            this.Headers.Add(new HttpHeader("Content-Type", "text/plain"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
