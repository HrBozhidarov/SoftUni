namespace Sis.Http.Requests
{
    using Enums;
    using Headers;
    using Headers.Contracts;
    using Requests.Contracts;
    using Common;
    using Cookies;
    using Cookies.Contracts;
    using Exceptions;
    using Exstensions;
    using Sessions.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public IDictionary<string, object> FormData { get; }

        public IDictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; private set; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public IHttpSession Session { get; set; }

        private void ParseRequest(string requestString)
        {
            var splitRequestContent = requestString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            var requestLine = splitRequestContent[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            this.ParseCookies();
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }

        private void ParseCookies()
        {
            var cookieParameters = this.Headers.GetHeader("Cookie");

            if (cookieParameters == null)
            {
                return;
            }

            foreach (var cookieParameter in cookieParameters.Value
                                    .Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries))
            {
                var kvp = cookieParameter.Split(new[] { '=' }, 2);

                if (kvp.Length != 2 || kvp[0] == "" || kvp[1] == "")
                {
                    continue;
                }

                var cooke = new HttpCookie(kvp[0], kvp[1], false);

                this.Cookies.Add(cooke);
            }
        }

        private void ParseRequestParameters(string requestBody)
        {
            this.ParseQueryParameters();
            this.ParseFormDataParameters(requestBody);
        }

        private void ParseFormDataParameters(string requestBody)
        {
            if (string.IsNullOrEmpty(requestBody))
            {
                return;
            }

            //
            requestBody = WebUtility.UrlDecode(requestBody);

            var formData = requestBody.Split('&');

            foreach (var data in formData)
            {
                var kvp = data.Split(new char[] { '=' }, 2);

                this.FormData[kvp[0]] = kvp[1];
            }
        }

        private void ParseQueryParameters()
        {
            if (!this.Url.Contains("?"))
            {
                return;
            }

            //.. can be problem
            var parameters = this.Url.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[1].Split('&');

            foreach (var parameter in parameters)
            {
                var kvp = parameter.Split('=').ToArray();

                if (!this.IsValidRequestQueryString(kvp))
                {
                    throw new BadRequestException();
                }

                this.QueryData[kvp[0]] = kvp[1];
            }
        }

        private bool IsValidRequestQueryString(string[] kvp)
        {
            if (kvp.Length != 2 || string.IsNullOrEmpty(kvp[0]) || string.IsNullOrEmpty(kvp[1]))
            {
                return false;
            }

            return true;
        }

        private void ParseHeaders(string[] requestHeaders)
        {
            var end = Array.IndexOf(requestHeaders, "");

            for (int i = 0; i < end; i++)
            {
                var currentHeader = requestHeaders[i];
                var splitHeader = currentHeader.Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

                if (splitHeader.Length == 1)
                {
                    continue;
                }

                this.Headers.Add(new HttpHeader(splitHeader[0], splitHeader[1]));
            }

            if (!this.Headers.ContainsHeader("Host"))
            {
                throw new BadRequestException();
            }
        }

        private void ParseRequestPath()
        {
            var path = this.Url.Split('?')[0].Substring(0);

            this.Path = path;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            var url = WebUtility.UrlDecode(requestLine[1]);

            this.Url = url;
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            var methodString = StringExtensions.Capitalize(requestLine[0]);

            if (!Enum.TryParse(methodString, out HttpRequestMethod method))
            {
                throw new InvalidOperationException(GlobalConstants.InvalidStatusCode);
            }

            this.RequestMethod = method;
        }

        private bool IsValidRequestLine(string[] requestLine)
        {
            if (requestLine.Length != 3 || requestLine[2] != "HTTP/1.1")
            {
                return false;
            }

            return true;
        }

        //private void SetSession()
        //{
        //    if (this.Cookies.ContainsCookie(HttpSessionStorage.SessionCookieKey))
        //    {
        //        var cookie = this.Cookies.GetCookie(HttpSessionStorage.SessionCookieKey);
        //        var sessionId = cookie.Value;

        //        this.Session = HttpSessionStorage.GetSession(sessionId);
        //    }
        //}
    }
}