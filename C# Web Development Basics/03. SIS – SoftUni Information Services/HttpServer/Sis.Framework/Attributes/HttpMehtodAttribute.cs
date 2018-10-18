using System;

namespace Sis.Framework.Attributes
{
    public abstract class HttpMehtodAttribute : Attribute
    {
        public abstract bool IsValid(string requestMethod);
    }
}
