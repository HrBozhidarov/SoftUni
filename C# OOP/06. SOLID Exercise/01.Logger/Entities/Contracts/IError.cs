using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Entities.Contracts
{
    public interface IError
    {
        string Message { get; }

        ErrorLevel ErrorLevel { get; }

        string Date { get; }
    }
}
