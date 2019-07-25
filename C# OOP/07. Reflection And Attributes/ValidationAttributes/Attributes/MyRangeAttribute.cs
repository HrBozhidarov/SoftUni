using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            int num;

            if (obj is int)
            {
                num = (int)obj;

                if (this.minValue > num || this.maxValue < num)
                {
                    return false;
                }

                return true;
            }

            return false;
        }
    }
}
