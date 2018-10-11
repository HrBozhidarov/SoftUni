namespace Sis.Http.Headers
{
    public class HttpHeader
    {
        public const string ContentLength = "Content-Length";
        public const string ContentDisposition = "Content-Disposition";

        public HttpHeader(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Key { get; }

        public string Value { get; }

        public override string ToString()
        {
            return $"{this.Key}: {this.Value}";
        }
    }
}
