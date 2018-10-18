namespace Sis.Framework.Attributes.Property
{
    using System.ComponentModel.DataAnnotations;

    public class NumberRangeAttribute : ValidationAttribute
    {
        private readonly double min;
        private readonly double max;

        public NumberRangeAttribute(double min,double max)
        {
            this.min = min;
            this.max = max;
        }

        public override bool IsValid(object value)
        {
            try
            {
                var num = (double)value;

                return !(num < min || num > max);
            }
            catch 
            {
                return false;
            }
        }
    }
}
