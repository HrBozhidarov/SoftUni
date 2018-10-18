namespace Sis.Framework.Attributes
{
    public class HttpGetAttribute : HttpMehtodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.ToUpper()!="GET")
            {
                return false;
            }

            return true;
        }
    }
}
