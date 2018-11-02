using SIS.MvcFramework;
using System;

namespace Turshia.App
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost.Start(new StartUp());
        }
    }
}
