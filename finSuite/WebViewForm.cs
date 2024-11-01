using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finSuite
{
    public partial class WebViewForm : Form
    {
        public WebViewForm()
        {
            InitializeComponent();
        }

        private void WebViewForm_Load(object sender, EventArgs e)
        {
            // WebView2 kontrolünü başlat
            webView21.EnsureCoreWebView2Async(null);

        
            // Blazor WebAssembly index.html dosyasını aç
            webView21.Source = new Uri("https://www.google.com/");
        }
    }
}
