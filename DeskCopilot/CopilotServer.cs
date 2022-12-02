using Fleck;

namespace DeskCopilot
{
    internal class CopilotServer
    {
        private readonly WebSocketServer server;

        private CopilotLayout[] layouts;

        public CopilotLayout[] Layouts
        {
            get
            {
                return layouts;
            }
            set
            {
                layouts = value;
                SendMessage(layouts);
            }
        }

        public CopilotServer(int port, CopilotLayout[] layouts)
        {
            server = new($"ws://127.0.0.1:{port}");
            server.Start(socket =>
            {
                socket.OnOpen = () => Console.WriteLine("Open!");
                socket.OnClose = () => Console.WriteLine("Close!");
                socket.OnMessage = message => ReceiveMessage(message);
                socket.OnBinary = bytes =>
                {

                };
            });
            this.layouts = layouts;
        }

        private void ReceiveMessage(string message)
        {

        }

        private void SendMessage(string message)
        {

        }

    }
}
