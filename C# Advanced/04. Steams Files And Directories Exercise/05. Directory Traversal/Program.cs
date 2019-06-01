using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace _05._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var directoryPath = Directory.GetParent(@"../../../").FullName;

            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("File was not found!");
            }
            else
            {
                var dir = new DirectoryInfo(directoryPath);
                var dictionary = new Dictionary<string, List<string>>();
                var files = dir.GetFiles();

                foreach (FileInfo fileInfo in files)
                {
                    if (!dictionary.ContainsKey(fileInfo.Extension))
                    {
                        dictionary[fileInfo.Extension] = new List<string>();
                    }
                    var length = (fileInfo.Length * 1.0) / 1000;

                    dictionary[fileInfo.Extension].Add($"--{fileInfo.Name} - {length}kb");
                }

                var sb = new StringBuilder();

                foreach (var item in dictionary.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {
                    sb.AppendLine(item.Key);

                    foreach (var line in item.Value.OrderBy(x => double.Parse(x.Split().Last().Split("kb")[0])))
                    {
                        sb.AppendLine(line);
                    }
                }

                var dekstopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";

                File.WriteAllText(dekstopPath, sb.ToString());
                Console.WriteLine("Report was created successfuly!");
            }
        }
    }
}
