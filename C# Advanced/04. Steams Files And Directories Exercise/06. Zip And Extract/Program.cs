using System;
using System.IO;
using System.IO.Compression;

namespace _06._Zip_And_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            var startupPath = Directory.GetParent(@"..\..\..\").FullName;
            var resourcePath = @"\start";
            var zipPathFolder = @"\zip\img.zip";
            var extractPathFolder = @"\extract";
            var startPath = startupPath + resourcePath;
            var zipPath = startupPath + zipPathFolder;
            var extractPath = startupPath + extractPathFolder;

            CreateZipFile(startPath, zipPath);

            ExtractZipFile(zipPath, extractPath);
        }

        private static void CreateZipFile(string SourcePath, string DestinationPath)
        {
            try
            {
                ZipFile.CreateFromDirectory(SourcePath, DestinationPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to create Zip file!" + ex.Message);
            }
        }

        private static void ExtractZipFile(string SourcePath, string DestinationPath)
        {
            try
            {
                ZipFile.ExtractToDirectory(SourcePath, DestinationPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to create Zip file!" + ex.Message);
            }
        }
    }
}
