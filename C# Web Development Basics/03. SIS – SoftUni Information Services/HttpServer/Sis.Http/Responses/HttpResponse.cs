namespace Sis.Http.Responses
{
    using Common;
    using Exstensions;
    using Enums;
    using Headers;
    using Headers.Contracts;
    using Responses.Contracts;
    using System.Text;
    using System;
    using System.Linq;

    public class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {

        }

        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
            this.StatusCode = statusCode;
        }

        public HttpResponseStatusCode StatusCode { get; private set; }

        public IHttpHeaderCollection Headers { get; private set; }

        public byte[] Content { get; protected set; }

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

            sb.Append($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}").Append(Environment.NewLine).Append(this.Headers.ToString()).Append(Environment.NewLine).Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}
