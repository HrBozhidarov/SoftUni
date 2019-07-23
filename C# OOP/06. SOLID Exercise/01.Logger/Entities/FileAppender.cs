using _01.Logger.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Entities
{
    public class FileAppender : IAppender
    {
        private ILayout layout;
        private ILogFile logFile;

        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
        {
            this.layout = layout;
            this.ErrorLevel = errorLevel;
            this.logFile = logFile;
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
            string formattedError = this.layout.FormatError(error);
            this.logFile.Write(formattedError);
            this.AppendMessageCount++;
        }

        public override string ToString()
        {
            string result = $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.ErrorLevel.ToString()}, Messages appended: {this.AppendMessageCount}, File size: {logFile.Size}";
            return result;
        }
    }
}
