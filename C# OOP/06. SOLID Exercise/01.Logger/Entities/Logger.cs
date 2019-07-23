using _01.Logger.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Entities
{
    public class Logger : ILogger
    {
        IEnumerable<IAppender> appenders;

        public Logger(IEnumerable<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

        public void Log(IError error)
        {
            foreach (var appender in this.appenders)
            {
                if (error.ErrorLevel >= appender.ErrorLevel)
                {
                    appender.AppendMessage(error);
                }
            }
        }
    }
}
