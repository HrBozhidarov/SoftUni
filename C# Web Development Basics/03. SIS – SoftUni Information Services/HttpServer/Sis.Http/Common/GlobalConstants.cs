namespace Sis.Http.Common
{
    public static class GlobalConstants
    {
        public const string HttpOneProtocolFragment = "HTTP/1.1";

        public const string HostHeaderKey = "Host";

        public const string BadRequestMessage = "400 Bad Request Response";

        public const string InternelServerErrorMessage = "500 Internal Server Error";

        public const string InvalidStatusCode = "This status code is not supported.";

        public static string[] ResourceExtensions = { ".js", ".css" };

        public const string DirectorySeparator = "/";

        public const string HtmlFileExtension = ".html";
    }
}
