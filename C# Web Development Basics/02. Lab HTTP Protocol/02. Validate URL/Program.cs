using System;
using System.Collections.Generic;
using System.Net;

namespace Validate_URL
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var url = Console.ReadLine();
                var decodeUrl = WebUtility.UrlDecode(url);

                var uri = new Uri(decodeUrl);

                var dic = new Dictionary<string, string>
                {
                    ["protocol"] = uri.Scheme,
                    ["host"] = uri.Host,
                    ["port"] = uri.Port.ToString(),
                    ["path"] = uri.LocalPath,
                    ["query"] = uri.Query == "" ? "" : uri.Query.Substring(1),
                    ["fragment"] = uri.Fragment == "" ? "" : uri.Fragment.Substring(1)
                };

                if ((dic["protocol"] == "https" && int.Parse(dic["port"]) != 443) || (dic["protocol"] == "http" && int.Parse(dic["port"]) != 80) || string.IsNullOrEmpty(dic["host"]) || string.IsNullOrEmpty(dic["path"]))
                {
                    throw new Exception();
                }

                foreach (var item in dic)
                {
                    if (item.Value == "")
                    {
                        continue;
                    }

                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
            catch
            {
                Console.WriteLine("Invalid URL");
            }
        }
    }
}
