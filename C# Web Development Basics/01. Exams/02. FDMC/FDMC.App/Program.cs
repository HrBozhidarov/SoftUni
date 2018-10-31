using SIS.MvcFramework;
using System;

namespace FDMC.App
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
