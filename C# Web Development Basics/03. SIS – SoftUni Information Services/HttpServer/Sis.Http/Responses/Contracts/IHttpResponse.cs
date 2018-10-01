namespace Sis.Http.Responses.Contracts
{
    using Enums;
    using Headers;
    using Headers.Contracts;

    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get;  }

        IHttpHeaderCollection Headers { get; }

        byte[] Content { get; }

        void AddHeader(HttpHeader header);

        byte[] GetBytes();
    }
}
