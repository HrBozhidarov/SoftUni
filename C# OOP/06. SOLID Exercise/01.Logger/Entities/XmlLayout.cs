using _01.Logger.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Entities
{
    public class XmlLayout : ILayout
    {
        private string Layout = "<log>" + Environment.NewLine +
                 "\t<date>{0}</date>" + Environment.NewLine +
                 "\t<level>{1}</level>" + Environment.NewLine +
                 "\t<message>{2}</message>" + Environment.NewLine +
                  "</log>";
        public string FormatError(IError error)
        {
            return string.Format(Layout, error.Date, error.ErrorLevel.ToString(), error.Message);
        }
    }
}
