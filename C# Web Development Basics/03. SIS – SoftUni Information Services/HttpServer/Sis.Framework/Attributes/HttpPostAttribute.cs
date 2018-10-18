namespace Sis.Framework.Attributes
{
    public class HttpPostAttribute : HttpMehtodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.ToUpper() != "POST")
            {
                return false;
            }

            return true;
        }
    }
}
