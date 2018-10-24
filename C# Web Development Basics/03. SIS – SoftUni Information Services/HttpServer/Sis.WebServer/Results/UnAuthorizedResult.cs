namespace Sis.WebServer.Results
{
    using Sis.Http.Headers;
    using Sis.Http.Responses;
    using System.Text;

    public class UnAuthorizedResult : HttpResponse
    {
        private const string DefaultErrorHeading
            = "<h1>You have no permission to access this functionality.</h1>";

        public UnAuthorizedResult()
            :base(Http.Enums.HttpResponseStatusCode.Unautorized)
        {
            this.Headers.Add(new HttpHeader(HttpHeader.ContentType, "text/html"));
            this.Content = Encoding.UTF8.GetBytes(DefaultErrorHeading);
        }
    }
}
