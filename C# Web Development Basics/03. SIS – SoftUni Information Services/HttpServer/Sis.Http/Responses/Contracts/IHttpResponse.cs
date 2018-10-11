namespace Sis.Http.Responses.Contracts
{
    using Cookies;
    using Cookies.Contracts;
    using Enums;
    using Headers;
    using Headers.Contracts;

    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; }

        IHttpHeaderCollection Headers { get; }

        byte[] Content { get; }

        void AddHeader(HttpHeader header);

        byte[] GetBytes();

        IHttpCookieCollection Cookies { get; }

        void AddCookie(HttpCookie cookie);
    }
}
