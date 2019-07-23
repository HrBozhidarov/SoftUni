using _01.Logger.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Entities
{
    public class ConsoleAppender : IAppender
    {
        private ILayout layout;

        public ConsoleAppender(ILayout layout, ErrorLevel errorLevel)
        {
            this.layout = layout;
            this.ErrorLevel = errorLevel;
        }

        public int AppendMessageCount
        {
            get;
            private set;
        }

        public ErrorLevel ErrorLevel
        {
            get;
            private set;
        }

        public void AppendMessage(IError error)
        {
            Console.WriteLine(this.layout.FormatError(error));
            this.AppendMessageCount++;
        }

        public override string ToString()
        {
            string result = $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.ErrorLevel.ToString()}, Messages appended: {this.AppendMessageCount}";
            return result;
        }
    }
}
