namespace ETHERNET
{
    public partial class ETHERNET : Form
    {
        public ETHERNET()
        {
            InitializeComponent();
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private async void ETHERNET_Load(object sender, EventArgs e)
        {
            await webView21.EnsureCoreWebView2Async(null);
            string filePath = Path.Combine(Application.StartupPath, "speedtest.html");
            webView21.Source = new Uri(filePath);
        }
    }
}
