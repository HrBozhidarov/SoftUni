using _01.Logger.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Entities.Factories
{
    public class AppenderFactory
    {
        const string DefaultFileName = "log{0}.txt";
        private LayoutFactory layoutFactory;
        private int fileNumber;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
        }

        public IAppender CreateAppender(string appenderType, string levelString, string layoutType)
        {
            var layout = this.layoutFactory.CreateLayout(layoutType);
            var errorLevel = this.ParseErrorLevel(levelString);

            switch (appenderType)
            {
                case "ConsoleAppender": return new ConsoleAppender(layout, errorLevel);
                case "FileAppender":
                    ILogFile logFile = new LogFile(string.Format(DefaultFileName, this.fileNumber));
                    return new FileAppender(layout, errorLevel, logFile);
                default:
                    throw new ArgumentException("Invalid Appender Type");
            }
        }

        private ErrorLevel ParseErrorLevel(string levelString)
        {
            try
            {
                object levelObj = Enum.Parse(typeof(ErrorLevel), levelString);
                return (ErrorLevel)levelObj;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Invalid ErrorLevel Tyep!", e.Message);
            }
        }
    }
}
