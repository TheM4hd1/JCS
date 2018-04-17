using System;
using System.Windows.Forms;
using System.IO;

namespace JCS_1._0.Utilities
{
    static class ReportGenerator
    {
        public static bool Create(ListView lvw, string url)
        {
            string tr = string.Empty;
            lvw.Invoke((MethodInvoker)delegate
            {


                foreach (ListViewItem item in lvw.Items)
                {
                    string[] td = new string[lvw.Columns.Count];
                    for (int i = 0; i < lvw.Columns.Count; i++)
                    {
                        td[i] = item.SubItems[i].Text;
                    }

                    string domainName;
                    if (td[3].Contains("exploit-db"))
                        domainName = "Exploit-db.com";
                    else
                        domainName = "PacketStormSecurity.com";
                    tr += string.Format("<tr>" +
                                        "<td>{0}</td>" +
                                        "<td>{1}</td>" +
                                        "<td>{2}</td>" +
                                        "<td><a href=\"{3}\" target=\"_blank\">{4}</a></td>" +
                                        "</tr> ", td[0], td[1], td[2], td[3], domainName) + Environment.NewLine;
                }
            });

            string html = Properties.Resources.html;
            string css = Properties.Resources.css;
            string js = Properties.Resources.js;

            html = html.Replace("_trReplace", tr);
            html = html.Replace("_site", url);
            html = html.Replace("_sName", url);

            try
            {
                if (!Directory.Exists("Reports"))
                    Directory.CreateDirectory("Reports");
                if (!Directory.Exists("Reports\\css"))
                    Directory.CreateDirectory("Reports\\css");
                if (!Directory.Exists("Reports\\js"))
                    Directory.CreateDirectory("Reports\\js");

                if (!File.Exists("Reports\\css\\style.css"))
                    File.WriteAllText("Reports\\css\\style.css", css);
                if (!File.Exists("Reports\\js\\index.js"))
                    File.WriteAllText("Reports\\js\\index.js", js);

                File.WriteAllText(string.Format("Reports\\Report {0}.html", DateTime.Now.ToString("yyyy-mm-dd")), html);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "JCS 0.9");
                return false;
            }

        }
    }
}
