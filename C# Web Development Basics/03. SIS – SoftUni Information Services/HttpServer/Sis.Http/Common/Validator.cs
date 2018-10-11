namespace Sis.Http.Common
{
    using System;

    public static class Validator
    {
        private const string NullExceptionMessage = "The {0} can not be null.";
        private const string NullOrEmptyExceptionMessage = "The {0} can not be null or empty.";

        public static void ValidationForNullAndEmpty(string value, string name)
        {
            if (string.IsNullOrEmpty(value?.Trim()))
            {
                throw new ArgumentNullException(string.Format(NullOrEmptyExceptionMessage, name));
            }
        }

        public static void ValidationForNull(object value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(string.Format(NullExceptionMessage, name));
            }
        }
    }
}