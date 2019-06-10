using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public double CalculateDiffrenceBetweenTwoDates(string firstDate, string secondDate)
        {
            var fDate = DateTime.Parse(firstDate);
            var sDate = DateTime.Parse(secondDate);

            return Math.Abs((fDate - sDate).TotalDays);
        }
    }
}
