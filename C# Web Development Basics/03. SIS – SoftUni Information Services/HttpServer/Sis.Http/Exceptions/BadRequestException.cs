namespace Sis.Http.Exceptions
{
    using System;

    public class BadRequestException : Exception
    {
        private const string DefaultBadRequestMessage = "The Request was malformed or contains unsupported elements.";

        public BadRequestException(string bedRequest = DefaultBadRequestMessage)
            : base(bedRequest)
        {
            
        }
    }
}
