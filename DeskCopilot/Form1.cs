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
               { new CopilotButton("TapButton", string.Empty,"", ButtonType.Press ), new CopilotButton("Test2", "Test", "", ButtonType.Press), new CopilotButton("Test3", "Test", "", ButtonType.Press) },
               { new CopilotButton("LongPressButton", string.Empty,"", ButtonType.LongPress ), new CopilotButton("Test5", "Test", "", ButtonType.Press), new CopilotButton("Test6", "Test", "", ButtonType.Press) },
               { new CopilotButton("TextButton", CopilotValue.GetCpuUsage().ToString(),"", ButtonType.Text ), new CopilotButton("Test8", "Test", "", ButtonType.Press), new CopilotButton("Test9", "Test", "", ButtonType.Press) },
               { new CopilotButton("TextButton", CopilotValue.GetCpuUsage().ToString(),"", ButtonType.Press ), new CopilotButton("Test11", "Test", "", ButtonType.Press), new CopilotButton("Test12", "Test", "", ButtonType.Press) },
               { new CopilotButton("Test13", "Test","", ButtonType.Press ), new CopilotButton("Test14", "Test", "", ButtonType.Press), new CopilotButton("Test15", "Test", "", ButtonType.Press) }
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
            server?.SetLayouts(new CopilotLayout[]  {
            new CopilotLayout("Test", "Test", new CopilotButton[,]
            {
               { new CopilotButton("TapButton", string.Empty,"", ButtonType.Press ), new CopilotButton("Test2", "Test", "", ButtonType.Press), new CopilotButton("Test3", "Test", "", ButtonType.Press) },
               { new CopilotButton("LongPressButton", string.Empty,"", ButtonType.LongPress ), new CopilotButton("Test5", "Test", "", ButtonType.Press), new CopilotButton("Test6", "Test", "", ButtonType.Press) },
               { new CopilotButton("TextButton", CopilotValue.GetCpuUsage().ToString(),"", ButtonType.Text ), new CopilotButton("Test8", "Test", "", ButtonType.Press), new CopilotButton("Test9", "Test", "", ButtonType.Press) },
               { new CopilotButton("TextButton", CopilotValue.GetCpuUsage().ToString(),"", ButtonType.Press ), new CopilotButton("Test11", "Test", "", ButtonType.Press), new CopilotButton("Test12", "Test", "", ButtonType.Press) },
               { new CopilotButton("Test13", "Test","", ButtonType.Press ), new CopilotButton("Test14", "Test", "", ButtonType.Press), new CopilotButton("Test15", "Test", "", ButtonType.Press) }
            })});
            //server?.Refresh();
        }
    }
}