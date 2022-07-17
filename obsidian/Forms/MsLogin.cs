using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace obsidian
{
    public partial class MsLogin : Form
    {
        public MsLogin()
        {
            InitializeComponent();
        }

        private void browser_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            string url = e.Uri;

            if (url.StartsWith("http://localhost/auth"))
            {
                string code = url.Split(new string[] { "?code=" }, StringSplitOptions.RemoveEmptyEntries).Last();
                Console.WriteLine(code);
                browser.NavigateToString("<h1>Please wait...</h1><p>We are logging you in now.</p>");
                //this.Close();
            }
        }

        private async void MsLogin_Load(object sender, EventArgs e)
        {
            await browser.EnsureCoreWebView2Async();
            browser.CoreWebView2.Navigate("https://login.live.com/oauth20_authorize.srf?client_id=1209955a-5179-4eee-85e1-189372b246e7&response_type=code&redirect_uri=http%3A%2F%2Flocalhost%2Fauth&scope=XboxLive.signin+offline_access");
        }
    }
}
