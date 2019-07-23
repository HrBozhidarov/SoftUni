using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Entities.Contracts
{
    public interface IAppender
    {
        void AppendMessage(IError error);

        int AppendMessageCount { get; }

        ErrorLevel ErrorLevel { get; }
    }
}
