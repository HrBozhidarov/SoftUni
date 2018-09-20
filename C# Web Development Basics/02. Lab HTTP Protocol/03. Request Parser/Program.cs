using System;
using System.Collections.Generic;

namespace Request_Parser
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var res = new Dictionary<string, HashSet<string>>();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var splitInput = input.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                var path = splitInput[0];
                var method = splitInput[1];

                if (!res.ContainsKey(path))
                {
                    res[path] = new HashSet<string>();
                }

                res[path].Add(method);
            }

            var request = Console.ReadLine().Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            var methodRequest = request[0].ToLower().Trim();
            var pathRequest = request[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];

            var statusCode = !res.ContainsKey(pathRequest) || !res[pathRequest].Contains(methodRequest) ? "404 NotFound" : "200 ok";

            Console.WriteLine($"HTTP/1.1 {statusCode}");
            Console.WriteLine($"Content-Length: {statusCode.Split()[1].Length}");
            Console.WriteLine("Content-Type: text/plain" + Environment.NewLine);
            Console.WriteLine($"{statusCode.Split()[1]}");
        }
    }
}
