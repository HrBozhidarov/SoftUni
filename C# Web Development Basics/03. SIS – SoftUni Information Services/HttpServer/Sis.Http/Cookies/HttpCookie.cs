namespace Sis.Http.Cookies
{
    using System;

    public class HttpCookie
    {
        private const int HttpCookieDefaultExpirationDays = 3;

        public HttpCookie(string key, string vale, bool isNew, int expires = HttpCookieDefaultExpirationDays)
            : this(key, vale, expires)
        {
            this.IsNew = isNew;
        }

        public HttpCookie(string key, string vale, int expires = HttpCookieDefaultExpirationDays)
        {
            this.Key = key;
            this.Value = vale;
            this.Expires = DateTime.UtcNow.AddDays(expires);
        }

        public string Key { get; }

        public string Value { get; }

        public DateTime Expires { get; private set; }

        public bool IsNew { get; } = true;

        public void Delete()
        {
            this.Expires = DateTime.UtcNow.AddDays(-1);
        }

        public override string ToString()
        {
            return $"{this.Key}={this.Value}; Expires={this.Expires.ToString("R")}";
        }
    }
}
