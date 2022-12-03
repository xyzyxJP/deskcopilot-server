using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace DeskCopilot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private CopilotServer? server;

        private void StartButton_Click(object sender, EventArgs e)
        {
            CopilotLayout[] layouts = new CopilotLayout[]  {
            new CopilotLayout("Test", "Test", new CopilotButton[,]
            {
               { new CopilotButton("Test1", "Test","", ButtonType.Tap ), new CopilotButton("Test2", "Test", "", ButtonType.Tap), new CopilotButton("Test3", "Test", "", ButtonType.Tap) },
               { new CopilotButton("Test4", "Test","", ButtonType.Tap ), new CopilotButton("Test5", "Test", "", ButtonType.Tap), new CopilotButton("Test6", "Test", "", ButtonType.Tap) },
               { new CopilotButton("Test7", "Test","", ButtonType.Tap ), new CopilotButton("Test8", "Test", "", ButtonType.Tap), new CopilotButton("Test9", "Test", "", ButtonType.Tap) },
               { new CopilotButton("Test10", "Test","", ButtonType.Tap ), new CopilotButton("Test11", "Test", "", ButtonType.Tap), new CopilotButton("Test12", "Test", "", ButtonType.Tap) },
               { new CopilotButton("Test13", "Test","", ButtonType.Tap ), new CopilotButton("Test14", "Test", "", ButtonType.Tap), new CopilotButton("Test15", "Test", "", ButtonType.Tap) }
            })};
            string address = NetworkInterface.GetAllNetworkInterfaces().Select(e => e.GetIPProperties()).Where(e => e.GatewayAddresses.Count != 0).First().UnicastAddresses.Where(e => e.Address.AddressFamily.Equals(AddressFamily.InterNetwork)).First().Address.ToString();
            int port = 8080;
            server = new(address, port, layouts);
            ServerAddressLabel.Text = $"Server Address: {address}";
            ServerPortLabel.Text = $"Server Port: {port}";
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            server?.Stop();
            ServerAddressLabel.Text = "Server Address: ";
            ServerPortLabel.Text = "Server Port: ";
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            server?.Refresh();
        }
    }
}