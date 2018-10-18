namespace Sis.Http.Exstensions
{
    using Common;
    using Enums;
    using System;

    public static class HttpResponseStatusExtensions
    {
        public static string GetResponseLine(this HttpResponseStatusCode statusCode)
        {
            var statusCodeNumber = (int)statusCode;

            switch (statusCode)
            {
                case HttpResponseStatusCode.OK: return $"{statusCodeNumber} OK";
                case HttpResponseStatusCode.Created: return $"{statusCodeNumber} Created";
                case HttpResponseStatusCode.Found: return $"{statusCodeNumber} Found";
                case HttpResponseStatusCode.Unautorized: return $"{statusCodeNumber} Unautorized";
                case HttpResponseStatusCode.Forbidden: return $"{statusCodeNumber} Forbidden";
                case HttpResponseStatusCode.NotFound: return $"{statusCodeNumber} Not Found";
                case HttpResponseStatusCode.SeeOther: return $"{statusCodeNumber} See Other";
                case HttpResponseStatusCode.BadRequest: return $"{statusCodeNumber} Bad Request";
                case HttpResponseStatusCode.InternalServerError: return $"{statusCodeNumber} Internel Server Error";
                default: throw new InvalidOperationException(GlobalConstants.InvalidStatusCode);
            }
        }
    }
}
