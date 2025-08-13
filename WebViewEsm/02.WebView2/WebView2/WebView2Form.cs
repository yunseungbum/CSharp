using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.WinForms;

namespace WebView2Browser
{
    public partial class WebView2Form : Form
    {
        public WebView2 WebView2 { get; set; }

        public TaskCompletionSource<bool> InitializationCompletionSource { get; set; } = new TaskCompletionSource<bool>();

        public WebView2Form()
        {
            InitializeComponent();
        }

        private void WebView2Form_Load(object sender, EventArgs e)
        {

        }           

        public async Task<bool> InitializeWebView2(bool isUseFixedWebView2 = false) 
        {
            try
            {
                WebView2 = new WebView2()
                {
                    Dock = DockStyle.Fill,
                };

                await WebView2.EnsureCoreWebView2Async();
                MainWebView2Panel.Controls.Add(WebView2);

                InitializationCompletionSource.SetResult(true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
   

        // Logic
        public async Task<string> ScriptResult(string script = null)
        {
            try
            {
                return await WebView2.CoreWebView2.ExecuteScriptAsync(script);
            }
            catch (Exception)
            {
                return "오류";
            }
        }

        public async Task<WebView2> HtmlNavgateToStringAsync(string html = null)
        {
            try
            {
                await InitializationCompletionSource.Task;

                if (WebView2 != null && WebView2.CoreWebView2 != null)
                {
                    WebView2.NavigateToString(html);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류: {ex.Message}");
            }
            return WebView2;
        }

        public async Task<WebView2> HtmlUriSoruceAsync(string path = null)
        {
            try
            {
                await InitializationCompletionSource.Task;

                if (WebView2 != null && WebView2.CoreWebView2 != null)
                {
                    WebView2.Source = new Uri(path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류: {ex.Message}");
            }
            return WebView2;
        }

       
    }
}
