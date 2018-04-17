using System;
using JCS_1._0.Forms;
using JCS_1._0.Utilities;
using JCS_1._0.Http;
using System.Windows.Forms;
using System.Threading;
using System.Net;

namespace JCS_1._0
{
    public partial class FrmMain : Form
    {
        string JoomlaVersion;
        public FrmMain()
        {
            InitializeComponent();
            nudScanT.Value = nudUpdateT.Value = nudCrawlerT.Value = Environment.ProcessorCount;
            nudScanTo.Value = nudUpdateTo.Value = nudCrawlerTo.Value = 2;
            nudScanMax.Value = nudUpdateMax.Value = nudCrawlMax.Value = 15;
        }

        private void httpOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmHttpOptions().Show();
        }

        private void identificationOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmIdentification().Show();
        }

        private void hTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(() =>
            {
                if (ReportGenerator.Create(lvwResult, txtUrl.Text))
                {
                    rtxScan.Invoke((MethodInvoker)delegate
                    {
                        rtxScan.AppendText(text: $"[{DateTime.Now.ToString("hh:mm:ss tt")}]\tReport created in '\\Reports' directory\n");
                    });
                }
            }))
            {
                IsBackground = true
            };
            t.Start();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {     
            rtxScan.AppendText($"[{DateTime.Now.ToString("hh:mm:ss tt")}]\t[+] Running up scanner...\n");
            txtUrl.Text = Helper.FixUrl(url: txtUrl.Text);
            VersionScanner versionScanner = new VersionScanner()
            {
                Url = txtUrl.Text
            };
            ComponentScanner componentScanner = new ComponentScanner()
            {
                Url = txtUrl.Text,
                Threads = (int)nudScanT.Value,
                TimeOut = (int)TimeSpan.FromSeconds(value: (double)nudScanTo.Value).TotalMilliseconds,
                MaxChecked = (int)nudScanMax.Value,
                Rtx = rtxScan,
                Prg = prgScan,
                Lvw = lvwResult,
                Lbl = lblScan
            };

            new Thread(new ThreadStart(() =>
            {
                JoomlaVersion = versionScanner.Scan();
                componentScanner.JoomlaVersion = JoomlaVersion;
                componentScanner.Scan();
            }))
            { IsBackground = true }.Start();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Databases.DatabaseUpdater databaseUpdater = new Databases.DatabaseUpdater(
                chbJcs.Checked,chbExpDb.Checked,chbExpAlert.Checked,chbPckStorm.Checked,
                threads: (int)nudUpdateT.Value, timeout: (int)TimeSpan.FromSeconds((double)nudUpdateTo.Value).TotalMilliseconds,
                rtx: rtxUpdate);
            databaseUpdater.MaxSleep = (int)nudUpdateMax.Value;
            databaseUpdater.UpdateDatabase();
        }

        private void btnCrawl_Click(object sender, EventArgs e)
        {
            txtCrawlerUrl.Text = Helper.FixUrl(url: txtCrawlerUrl.Text);
            Crawler crawler = new Crawler()
            {
                Url = new Uri(uriString: txtCrawlerUrl.Text).Host,
                Threads = (int)nudCrawlerT.Value,
                TimeOut = (int)TimeSpan.FromSeconds(value: (double)nudCrawlerTo.Value).TotalMilliseconds,
                maxRequests = (int)nudCrawlMax.Value,
                rtx = rtxCrawler,
                trw = trwCrawler,
                lbx = lbxCrawler
            };
            
            new Thread(new ThreadStart(() =>
            {
                //crawler.Crawl(url: txtCrawlerUrl.Text);
                crawler.Run(url: txtCrawlerUrl.Text);
                rtxCrawler.Invoke(method: (MethodInvoker)delegate
                {
                    rtxCrawler.AppendText(text: $"[{DateTime.Now.ToString("hh:mm:ss tt")}]\t[+] Crawler finished the job.\n");
                });
                trwCrawler.Invoke(method: (MethodInvoker)delegate
                {
                    trwCrawler.Sort();
                });

            }))
            {
                IsBackground = true
            }.Start();
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lvwResult.Items.Count>0)
            {
                DialogResult drt = MessageBox.Show("Are you sure to exit without saving results?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(drt == DialogResult.Yes)
                {
                    Close();
                }
                else if(drt == DialogResult.No)
                {
                    return;
                }
            }
            Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.Reflection.Assembly.GetEntryAssembly().Location);
            Close();
        }

        private void viewExploitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new FrmDetails(ExploitViewer.GrabInfo(link: lvwResult.FocusedItem.SubItems[3].Text)).Show();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(text: "Please select an item.\n", caption: "JCS 1.0", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }
        }

        private void copyLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(text: lvwResult.FocusedItem.SubItems[3].Text);
                rtxScan.AppendText(text: $"[{DateTime.Now.ToString("hh:mm:ss tt")}]\t[+] Copied to clipboard\n");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(text: "Please select an item.\n", caption: "JCS 1.0", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }
            
        }

        private void clearListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvwResult.Items.Clear();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AboutUs().Show();
        }

        private void copyComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(text: lbxCrawler.SelectedItem.ToString());
                rtxCrawler.AppendText(text: $"[{DateTime.Now.ToString("hh:mm:ss tt")}]\t[+] Copied to clipboard\n");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(text: "Please select an item.\n", caption: "JCS 1.0", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            string path = string.Empty, data = string.Empty;
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sfd.FileName);
                foreach(var a in lbxCrawler.Items)
                {
                    SaveFile.WriteLine(a.ToString());
                }
                SaveFile.Close();
                rtxCrawler.AppendText(text: $"[{DateTime.Now.ToString("hh:mm:ss tt")}]\t[+] Saved to {sfd.FileName}\n");
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(text: trwCrawler.SelectedNode.ToString());
                rtxCrawler.AppendText(text: $"[{DateTime.Now.ToString("hh:mm:ss tt")}]\t[+] Copied to clipboard\n");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(text: "Please select an item.\n", caption: "JCS 1.0", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            string path = string.Empty, data = string.Empty;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sfd.FileName);
                foreach (var a in trwCrawler.Nodes)
                {
                    SaveFile.WriteLine(a.ToString());
                }
                SaveFile.Close();
                rtxCrawler.AppendText(text: $"[{DateTime.Now.ToString("hh:mm:ss tt")}]\t[+] Saved to {sfd.FileName}\n");
            }
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmUserGuide().Show();
        }
    }
}
