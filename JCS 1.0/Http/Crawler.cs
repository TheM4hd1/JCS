using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using JCS_1._0.Utilities;
using System.Text.RegularExpressions;
using System.Threading;
namespace JCS_1._0.Http
{
    class Crawler : TargetSettings
    {
        #region V A R S
        public RichTextBox rtx;
        public TreeView trw;
        public ListBox lbx;

        List<string> linkParameters = new List<string>();
        List<string> linkDb = new List<string>();
        object lockRequests = new object();

        string parametersPattern = @"[\?&](([^&=]+))";
        public int maxRequests;
        int requests;
#endregion
        public Crawler()
        {
            TargetSettings targetSettings = new TargetSettings();
        }

        public void Run(string url)
        {
            rtx.Invoke(method: (MethodInvoker)delegate
            {
                rtx.AppendText(text: $"[{DateTime.Now.ToString("hh:mm:ss tt")}]\t[+] Crawling...\n");
            });

            try
            {
                requests = 1;
                HttpResponseMessage responseMessage = HttpClient.GetAsync(requestUri: url).Result;
                string html = responseMessage.Content.ReadAsStringAsync().Result;
                int maxThreads = LinkFinder.Find(html).Count;
                if(Threads>maxThreads)
                {
                    rtx.Invoke(method: (MethodInvoker)delegate
                    {
                        rtx.AppendText(text: $"[{DateTime.Now.ToString("hh:mm:ss tt")}]\tAlert: Decreasing threads to {maxThreads}\n");
                    });
                }
                foreach(var s in LinkFinder.Find(html))
                {
                    new Thread(new ThreadStart(() =>
                    {
                        FollowLink(s.Href);
                    }))
                    {
                        IsBackground = true
                    }.Start();
                }
            }
            catch { };

            Crawl(url);
        }

        private void Crawl(string url)
        {
            // open index -> gatherlinks -> add to list -> {check for component} -> follow links
            try
            {
                HttpResponseMessage responseMessage = HttpClient.GetAsync(requestUri: url).Result;
                string html = responseMessage.Content.ReadAsStringAsync().Result;
                GatherLinks(source: html);
            }
            catch(Exception ex)
            {
                rtx.Invoke(method: (MethodInvoker)delegate
                {
                    rtx.AppendText(text: $"[-] Error url: {url}\n");
                    rtx.AppendText(text: $"[-] Error description: {ex.Message}\n");
                });
            };
        }

        private void GatherLinks(string source)
        {
            foreach(LinkItem i in LinkFinder.Find(source))
            {
                string u = i.Href;
                if (i.Href.StartsWith(value: "/") || i.Href.Contains(value: Url))
                {  
                    if (linkDb.IndexOf(item: i.Href)<0)
                    {
                        if (CheckBlackList(url: i.Href))
                        {
                            if (GetLinkParameteres(url: i.Href))
                            {
                                linkDb.Add(item: i.Href);
                                if (i.Href.StartsWith("/"))
                                {
                                    u = "http://" + Url + i.Href;
                                }
                                trw.Invoke(method: (MethodInvoker)delegate
                                {
                                    trw.Nodes.Add(u);
                                });
                                FollowLink(url: i.Href);
                            }
                        }
                    }
                    
                }
            }
        }

        private bool CheckBlackList(string url)
        {
            foreach (string e in CrawlerOptions.ReturnBlackList())
            {
                if (url.EndsWith(value: e))
                {
                    return false;
                }
            }

            return true;
        }

        public bool GetLinkParameteres(string url)
        {
            if(Regex.IsMatch(input: url, pattern: parametersPattern))
            {
                var matches = Regex.Matches(input: url, pattern: parametersPattern);
                string parameters = string.Empty ;
                foreach(var m in matches)
                {
                    parameters = parameters + m;
                }

                parameters = parameters + FindComponent(link: url);
                if (linkParameters.IndexOf(item: parameters) < 0)
                {
                    linkParameters.Add(item: parameters);
                    return true;
                }
                else
                {   
                    return false;
                }
            }

            return true;
        }

        private string FindComponent(string link)
        {
            if(Regex.IsMatch(input: link,pattern: CrawlerOptions.RegexPattern))
            {
                string item = Regex.Match(input: link, pattern: CrawlerOptions.RegexPattern).Value;

                lbx.Invoke(method: (MethodInvoker)delegate
                {
                    if (lbx.Items.IndexOf(value: item) < 0)
                    {
                        lbx.Items.Add(item: item);
                    }
                });

                return item;
                
            }

            return string.Empty;
        }

        private void FollowLink(string url)
        {
            lock (lockRequests)
            {
                if (maxRequests == requests)
                {
                    Thread.Sleep(millisecondsTimeout: TimeOut);
                    requests = 0;
                }
                else
                {
                    requests++;
                }
            }
            if (url.StartsWith(value: "/") && CheckBlackList(url: url))
            {
                Crawl(url: $"http://{Url}{url}");
            }
            else if(url.Contains(value: Url))
            {
                Crawl(url: Helper.FixUrl(url: url));
            }
        }
    }
}
