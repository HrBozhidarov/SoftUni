namespace Sis.Http.Requests.Contracts
{
    using Enums;
    using Headers.Contracts;
    using System.Collections.Generic;

    public interface IHttpRequest
    {
        string Path { get; }

        string Url { get; }

        IDictionary<string,object> FormData { get; }

        IDictionary<string, object> QueryData { get; }

        IHttpHeaderCollection Headers { get; }

        HttpRequestMethod RequestMethod { get; }
    }
}
