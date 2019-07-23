using _01.Logger.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Entities
{
    public class Error : IError
    {
        public Error(string date, string message, ErrorLevel errorLevel)
        {
            this.Date = date;
            this.Message = message;
            this.ErrorLevel = errorLevel;
        }

        public string Message { get; }

        public ErrorLevel ErrorLevel { get; }

        public string Date { get; }
    }
}
