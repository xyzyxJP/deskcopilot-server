using Fleck;
using Newtonsoft.Json;

namespace DeskCopilot
{
    internal class CopilotServer
    {
        private readonly WebSocketServer server;
        private readonly List<IWebSocketConnection> sockets;

        private CopilotLayout[] layouts;

        public CopilotServer(string address, int port, CopilotLayout[] layouts)
        {
            sockets = new List<IWebSocketConnection>();
            server = new($"ws://{address}:{port}");
            server.Start(socket =>
            {
                socket.OnOpen = () => sockets.Add(socket);
                socket.OnClose = () => sockets.Remove(socket);
                socket.OnMessage = message => ReceiveMessage(socket, message);
                socket.OnBinary = bytes =>
                {

                };
            });
            this.layouts = layouts;
        }

        public void SetLayouts(CopilotLayout[] layouts)
        {
            this.layouts = layouts;
            SendMessage(JsonConvert.SerializeObject(layouts));
        }

        public void Stop()
        {
            server.Dispose();
        }

        public void Refresh()
        {
            SendMessage(JsonConvert.SerializeObject(layouts));
        }

        private void ReceiveMessage(IWebSocketConnection socket, string message)
        {
            switch (message)
            {
                case "layouts":
                    socket.Send(JsonConvert.SerializeObject(layouts));
                    break;
                default:
                    socket.Send(message);
                    break;
            }
        }

        private void SendMessage(string message)
        {
            sockets.ForEach(socket => { socket.Send(message); });
        }

    }
}
