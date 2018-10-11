namespace Sis.Http.Requests.Contracts
{
    using Cookies.Contracts;
    using Enums;
    using Headers.Contracts;
    using Sessions.Contracts;
    using System.Collections.Generic;

    public interface IHttpRequest
    {
        string Path { get; }

        string Url { get; }

        IDictionary<string,object> FormData { get; }

        IDictionary<string, object> QueryData { get; }

        IHttpHeaderCollection Headers { get; }

        HttpRequestMethod RequestMethod { get; }

        IHttpCookieCollection Cookies { get; }

        IHttpSession Session { get; set; }
    }
}
