using System;
using System.IO;

namespace _04._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            var startupPath = Directory.GetParent(@"../../../").FullName;
            var resourcePath = "/Resources/copyMe.png";
            var outputPath = "/Resources/img.png";
            var readPath = startupPath + resourcePath;
            var writePath = startupPath + outputPath;

            if (!File.Exists(readPath))
            {
                Console.WriteLine("File was not found!");
            }
            else
            {
                using (BinaryReader reader = new BinaryReader(File.Open(readPath, FileMode.Open)))
                {
                    using (BinaryWriter writer = new BinaryWriter(File.Open(writePath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[1024];
                        int bytesRead;

                        while ((bytesRead = reader.Read(buffer, 0, 1024)) > 0)
                        {
                            writer.Write(buffer, 0, bytesRead);
                        }
                    }
                }

                Console.WriteLine("Picture was copyed!");
            }
        }
    }
}
