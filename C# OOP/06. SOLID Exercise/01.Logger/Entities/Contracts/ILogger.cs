using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Entities.Contracts
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Log(IError error);
    }
}
