namespace Sis.Http.Responses
{
    using Common;
    using Cookies;
    using Cookies.Contracts;
    using Exstensions;
    using Enums;
    using Headers;
    using Headers.Contracts;
    using Responses.Contracts;
    using System;
    using System.Linq;
    using System.Text;

    public class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {

        }

        public HttpResponse(HttpResponseStatusCode statusCode, string path = "/")
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
            this.StatusCode = statusCode;
            this.Cookies = new HttpCookieCollection();
            this.Path = path;
        }

        public HttpResponseStatusCode StatusCode { get; private set; }

        public IHttpHeaderCollection Headers { get; private set; }

        public IHttpCookieCollection Cookies { get; private set; }

        public string Path { get; set; }

        public byte[] Content { get; protected set; }

        public void AddCookie(HttpCookie cookie)
        {
            this.Cookies.Add(cookie);
        }

        public void AddHeader(HttpHeader header)
        {
            Validator.ValidationForNull(header, nameof(header));

            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            return Encoding.UTF8.GetBytes(this.ToString()).Concat(this.Content).ToArray();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}").Append(Environment.NewLine).Append(this.Headers.ToString()).Append(Environment.NewLine);

            foreach (var cookie in this.Cookies)
            {
                sb.Append($"Set-Cookie: {cookie}; path={Path}").Append(Environment.NewLine);
            }

            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}