using System;
using System.Collections.Generic;
using System.Text;

namespace Sis.Framework.Attributes
{
    public class HttpDeleteAttribute : HttpMehtodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.ToUpper() != "DELETE")
            {
                return false;
            }

            return true;
        }
    }
}
