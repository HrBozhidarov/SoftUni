using Sis.WebServer;

namespace Sis.Framework
{
    public static class MvcEngine
    {
        public static void Run(Server server)
        {
            try
            {
                server.Run();
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
