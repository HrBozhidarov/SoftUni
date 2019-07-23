using _01.Logger.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Entities
{
    public class SimpleLayout : ILayout
    {
        private const string Layout = "{0} - {1} - {2}";
        public string FormatError(IError error)
        {
            return string.Format(Layout, error.Date, error.ErrorLevel.ToString(), error.Message);
        }
    }
}
