namespace Sis.Http.Headers
{
    using Common;
    using Headers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private const string KeyNotFound = "The given key does not contains in headers";

        private readonly IDictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader httpHeader)
        {
            Validator.ValidationForNull(httpHeader,nameof(httpHeader));
            Validator.ValidationForNullAndSpace(httpHeader.Key, nameof(httpHeader.Key));
            Validator.ValidationForNullAndSpace(httpHeader.Value, nameof(httpHeader.Value));

            this.headers[httpHeader.Key] = httpHeader;
        }

        public bool ContainsHeader(string key)
        {
            Validator.ValidationForNullAndSpace(key, key);

            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            if (!this.headers.ContainsKey(key))
            {
                return null;
            }

            return this.headers[key];
        }

        public override string ToString()
        {
            var stringHeaders = this.headers.Select(x => x.Value.ToString());

            return string.Join(Environment.NewLine, stringHeaders).Trim();
        }
    }
}
