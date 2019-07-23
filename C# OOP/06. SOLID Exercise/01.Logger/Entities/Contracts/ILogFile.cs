using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Entities.Contracts
{
    public interface ILogFile
    {
        void Write(string errorLog);

        int Size { get; }

        string Path { get; }
    }
}
