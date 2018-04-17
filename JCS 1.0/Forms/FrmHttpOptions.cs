using System;
using System.Windows.Forms;
using JCS_1._0.Http;
namespace JCS_1._0.Forms
{
    public partial class FrmHttpOptions : Form
    {
        public FrmHttpOptions()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            HttpOptions.IsHttpOptions = true;
            HttpOptions.HttpUserAgent = txtUserAgent.Text;
            HttpOptions.IsProxy = chbProxy.Checked;
            HttpOptions.IsAuthentication = chbAuth.Checked;

            if (HttpOptions.IsProxy)
            {
                HttpOptions.ProxyFullAddress = $"{txtHost.Text}:{txtPort.Text}";
                HttpOptions.IsProxyAuthentication = chbProxyAuth.Checked;
                if (HttpOptions.IsProxyAuthentication)
                {
                    HttpOptions.ProxyCredentials = $"{txtProxyUser.Text}:{txtProxyPass.Text}";
                }
            }

            if (HttpOptions.IsAuthentication)
            {
                HttpOptions.Credentials = $"{txtAuthUser.Text}:{txtAuthPass.Text}";
                HttpOptions.AuthenticationType = cbxAuth.SelectedText;
            }

            Utilities.CrawlerOptions.RegexPattern = txtCrawlerPattern.Text;
            Utilities.CrawlerOptions.BlackList = txtCrawlerBlacklist.Text;
            if (!Utilities.CrawlerOptions.IsValidRegex())
            {
                MessageBox.Show("Invalid Crawler Pattern!", "Regex Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Close();
        }

        private void btnAddHeader_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem
            {
                Text = txtHeader.Text
            };
            lvi.SubItems.Add(txtValue.Text);
            HttpOptions.HttpHeaders.Add(txtHeader.Text, txtValue.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HttpOptions.IsHttpOptions = false;
            Close();
        }

        private void chbProxy_CheckedChanged(object sender, EventArgs e)
        {
            txtHost.Enabled = chbProxy.Checked;
            txtPort.Enabled = chbProxy.Checked;
            chbProxyAuth.Enabled = chbProxy.Checked;
        }

        private void chbProxyAuth_CheckedChanged(object sender, EventArgs e)
        {
            txtProxyUser.Enabled = chbProxyAuth.Checked;
            txtProxyPass.Enabled = chbProxyAuth.Checked;
        }

        private void chbAuth_CheckedChanged(object sender, EventArgs e)
        {
            txtAuthPass.Enabled = chbAuth.Checked;
            txtAuthUser.Enabled = chbAuth.Checked;
            cbxAuth.Enabled = chbAuth.Checked;
        }
    }
}
