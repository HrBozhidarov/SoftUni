using _01.Logger.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _01.Logger.Entities
{
    public class LogFile : ILogFile
    {
        private const string DefaultPath = "../";

        public LogFile(string fileName)
        {
            this.Path = DefaultPath + fileName;
        }

        public int Size
        {
            get;
            private set;
        }

        public string Path
        {
            get;
            private set;
        }

        public void Write(string errorLog)
        {
            File.AppendAllText(this.Path, errorLog + Environment.NewLine);

            int addedSize = 0;

            foreach (var letter in errorLog.Where(c => char.IsLetter(c)))
            {
                addedSize += letter;
            }

            this.Size += addedSize;
        }
    }
}
