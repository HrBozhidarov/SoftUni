namespace Sis.Http.Cookies
{
    using Common;
    using Contracts;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly IDictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie cookie)
        {
            Validator.ValidationForNull(cookie, nameof(cookie));
            Validator.ValidationForNullAndEmpty(cookie.Key, nameof(cookie.Key));
            Validator.ValidationForNullAndEmpty(cookie.Value, nameof(cookie.Value));

            this.cookies[cookie.Key] = cookie;
        }

        public bool ContainsCookie(string key)
        {
            if (key == null)
            {
                return false;
            }

            return this.cookies.ContainsKey(key);
        }

        public HttpCookie GetCookie(string key)
        {
            if (!ContainsCookie(key))
            {
                return null;
            }

            return this.cookies[key];
        }

        //public bool IfCookieIsNew(string key, string value)
        //{
        //    if (!this.ContainsCookie(key) || value == null)
        //    {
        //        return false;
        //    }

        //    if (this.cookies[key].Value!=value)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        public bool HasCookies()
        {
            return this.cookies.Any(x => x.Value.IsNew);
        }

        public IEnumerator<HttpCookie> GetEnumerator()
        {
            foreach (var httoCookie in this.cookies.Values)
            {
                yield return httoCookie;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString()
        {
            return string.Join("; ", this.cookies.Values);
        }

        public void Clear()
        {
            this.cookies.Clear();
        }
    }
}
