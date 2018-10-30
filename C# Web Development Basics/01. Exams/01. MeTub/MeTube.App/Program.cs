using SIS.MvcFramework;
using System;

namespace MeTube.App
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost.Start(new StartUp());
        }
    }
}
