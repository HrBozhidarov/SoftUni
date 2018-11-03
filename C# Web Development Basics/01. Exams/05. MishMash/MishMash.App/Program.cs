using SIS.MvcFramework;
using System;

namespace MishMash.App
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
