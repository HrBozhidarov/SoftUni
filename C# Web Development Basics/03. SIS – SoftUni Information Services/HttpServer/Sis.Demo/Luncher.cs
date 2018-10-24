namespace Sis.Demo
{
    using Sis.Framework;

    class Luncher
    {
        static void Main(string[] args)
        {
            WebHost.Start(new StartUp());
        }
    }
}
