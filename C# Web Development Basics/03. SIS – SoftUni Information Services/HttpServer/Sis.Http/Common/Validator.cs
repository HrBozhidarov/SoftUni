namespace Sis.Http.Common
{
    using System;

    public static class Validator
    {
        private const string NullExceptionMessage = "The {0} can not be null";

        public static void ValidationForNullAndSpace(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(string.Format(NullExceptionMessage, name));
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
