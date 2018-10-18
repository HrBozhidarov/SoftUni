namespace Sis.WebServer.Api.Contracts
{
    using Http.Requests.Contracts;
    using Http.Responses.Contracts;

    public interface IHttpHeandler
    {
        IHttpResponse Handle(IHttpRequest httpRequest);
    }
}
