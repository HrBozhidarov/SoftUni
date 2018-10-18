namespace Sis.WebServer
{
    using Sis.WebServer.Api.Contracts;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    public class Server
    {
        private const string LocalHostIpAddress = "127.0.0.1";

        private readonly int port;
        private readonly TcpListener listener;
        private readonly IHttpHandlingContext handlersContext;
        private bool isRunning;

        public Server(int port, IHttpHandlingContext handlersContext)
        {
            this.port = port;
            this.handlersContext = handlersContext;
            this.listener = new TcpListener(IPAddress.Parse(LocalHostIpAddress), port);
        }

        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server started at http://{LocalHostIpAddress}:{this.port}");

            this.ListenLoop().GetAwaiter().GetResult();
        }

        public async Task ListenLoop()
        {
            while (this.isRunning)
            {
                var client = await this.listener.AcceptSocketAsync();

                await Task.Run(async () =>
               {
                   var connectionHandler = new ConnectionHandler(client, this.handlersContext);
                   await connectionHandler.ProcessRequestAsync();
               });
            }
        }
    }
}