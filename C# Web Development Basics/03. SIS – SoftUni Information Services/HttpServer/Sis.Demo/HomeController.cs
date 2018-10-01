namespace Sis.Demo
{
    using Http.Enums;
    using Http.Responses.Contracts;
    using WebServer.Results;

    public class HomeController
    {
        public IHttpResponse Index()
        {
            var content = "<h1>Hi Friend</h1>";

            return new HtmlResult(content, HttpResponseStatusCode.OK);
        }
    }
}
