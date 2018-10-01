namespace Sis.Http.Exceptions
{
    using System;

    public class InternalServerErrorException : Exception
    {
        private const string InternelServerErrorDefaultMessage = "The Server has encountered an error.";

        public InternalServerErrorException(string internelServerError = InternelServerErrorDefaultMessage)
            : base(internelServerError)
        {

        }
    }
}
