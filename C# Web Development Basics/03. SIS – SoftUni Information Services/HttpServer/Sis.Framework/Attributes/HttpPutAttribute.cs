namespace Sis.Framework.Attributes
{
    public class HttpPutAttribute : HttpMehtodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.ToUpper() != "PUT")
            {
                return false;
            }

            return true;
        }
    }
}
