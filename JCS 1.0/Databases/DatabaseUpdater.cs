using JCS_1._0.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace JCS_1._0.Databases
{
    class DatabaseUpdater
    {
        #region V A R S
        bool Jcs, Exploitdb, Exploitalert, Packetstorm;
        string TempPath,ExploitID;
        const string Jcs_Server = "";
        const string Exploitdb_Server = "https://www.exploit-db.com/exploits/";
        const string Exploitalert_Server = "";
        const string Packetstorm_Server = "https://packetstormsecurity.com/search/?q=joomla";
        const string Packestorm_Page_Address = "https://packetstormsecurity.com/search/files/$page/?q=joomla";
        const string Component_Pattern = @"(com_)\w*[A-Za-z0-9\-]\w+";
        const string Date_Pattern = @"\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])";
        const string Number_Of_Exploits = @"(of )+[0-9]+(,)+[0-9]\d\d";
        const string Page_Number_Pattern = @"(Page )[0-9]( of )[0-9]\w*";
        const string End_Page_Pattern = @"<h1>No Results Found</h1>";
        int Threads, Timeout;
        public int MaxSleep;
        short ErrorCode;
        List<string> ComponentsList,
            ExploitdbList,
            PacketstormList,
            ExploitalertList;
        VersionDetector versionDetector;
        System.Windows.Forms.RichTextBox Rtx;
#endregion
        public DatabaseUpdater(bool jcs,bool exploitdb,bool exploitalert,bool packetstorm,int threads,int timeout, System.Windows.Forms.RichTextBox rtx)
        {
            Jcs = jcs;
            Exploitdb = exploitdb;
            Exploitalert = exploitalert;
            Packetstorm = packetstorm;
            Threads = threads;
            Timeout = timeout;
            TempPath = Path.GetTempPath();
            ErrorCode = 0x0; // unkown error
            Rtx = rtx;
            ComponentsList = new List<string>();
            ExploitalertList = new List<string>();
            ExploitdbList = new List<string>();
            PacketstormList = new List<string>();
            versionDetector = new VersionDetector();
        }

        private void UpdateRtx(string txt)
        {
            Rtx.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                Rtx.AppendText($"[{DateTime.Now.ToString("hh:mm:ss tt")}]\t{txt}\n");
            });
        }

        private void CheckPriority()
        {
            if (Exploitdb)
            {
                UpdateExploitdb();
            }
            else if (Packetstorm)
            {
                UpdatePacketstorm();
            }
            else if(Jcs)
            {
                UpdateJcs();
            }
            else
            {
                CleanAndSave();
            }
        }

        private void CleanAndSave()
        {
            UpdateRtx("[+] Saving file...");
            ComponentsList = ExploitdbList.Concat(PacketstormList).Concat(ExploitalertList).ToList();
            if (!Directory.Exists(path: "Databases"))
                Directory.CreateDirectory(path: "Databases");
            //File.WriteAllLines(path: "Databases\\database.txt", contents: ComponentsList); // id,description,component
            List<DatabaseItems> jsonDatabase = new List<DatabaseItems>();
            foreach(string s in ComponentsList)
            {
                string[] info = s.Split(':');
                jsonDatabase.Add(new DatabaseItems()
                {
                    id = info[0],
                    description = info[1],
                    component = info[2],
                    version = info[3],
                    exploit = ""
                });
            }
            string data = JsonConvert.SerializeObject(jsonDatabase.ToArray(),Formatting.Indented);
            File.WriteAllText(path: "Databases\\database.txt", contents: data);
            UpdateRtx(txt: "[+] Cleaning...");

            if(File.Exists(path: Path.Combine(path1: TempPath, path2: "db.csv")))
            {
                File.Delete(path: Path.Combine(path1: TempPath, path2: "db.csv"));
            }
            ComponentsList = new List<string>();
            ExploitalertList = new List<string>();
            ExploitdbList = new List<string>();
            PacketstormList = new List<string>();
            jsonDatabase = new List<DatabaseItems>();
            
            UpdateRtx(txt: "Done.");
        }

        public void UpdateDatabase()
        {
            CheckPriority();
        }

        private void UpdateExploitdb()
        {
            try
            {
                new Thread(new ThreadStart(() =>
                {
                    UpdateRtx(txt: $"[+] Downloading exploit database from offensive-security's github...");
                    using (WebClient webClient = new WebClient())
                    {
                        ErrorCode = 0x1; // error in connecting to github server
                        webClient.DownloadFile(
                            "https://raw.githubusercontent.com/offensive-security/exploit-database/master/files_exploits.csv",
                            Path.Combine(TempPath, "db.csv"));
                    }
                    ErrorCode = 0x2; // error in reading file
                    UpdateRtx(txt: "[+] Reading database...");
                    string[] csvDatabase = File.ReadAllLines(Path.Combine(TempPath, "db.csv"));
                    UpdateRtx(txt: "[+] Searching for components...");
                    UpdateRtx(txt: $"[+] Exploitdb Components: {ExploitdbList.Count}");
                    ParallelOptions parallelOptions = new ParallelOptions()
                    {
                        MaxDegreeOfParallelism = Threads
                    };

                    int sleepCounter = 0;
                    object sleepLock = new object();
                    try
                    {
                        Parallel.ForEach(csvDatabase.ToArray().ToList(), parallelOptions, match =>
                        {
                            if (match.ToLower().Contains("joomla"))
                            {
                                string[] info = match.Split(',');
                                string id = info[0],
                                description = info[2],
                                component = string.Empty,
                                version = "n\a",
                                webpageSource = string.Empty;

                                using (WebClient webClient = new WebClient())
                                {
                                    ErrorCode = 0x3; // error in searching components
                                    ExploitID = id;
                                    webClient.Headers.Add(name: "user-agent",
                                        value: " Mozilla/5.0 (Windows NT 6.1; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0");
                                    try
                                    {
                                        webpageSource = webClient.DownloadString(address: $"{Exploitdb_Server}{id}");

                                        if (Regex.IsMatch(webpageSource, Date_Pattern))
                                        {
                                            version = versionDetector.GetVersion(
                                                date: Regex.Match(input: webpageSource,
                                                pattern: Date_Pattern)
                                                .Value);
                                        }

                                        if (Regex.IsMatch(input: description, pattern: Component_Pattern))
                                        {
                                            component = Regex.Match(
                                                input: description,
                                                pattern: Component_Pattern)
                                                .Value;
                                        }
                                        else
                                        {
                                            webpageSource = webpageSource.Substring(startIndex: 0,
                                                length: webpageSource.IndexOf(
                                                    value: "<h2>Related Exploits</h2>")); // prevent adding related components
                                            if (Regex.IsMatch(input: webpageSource, pattern: Component_Pattern))
                                            {
                                                component = Regex.Match(input: webpageSource,
                                                    pattern: Component_Pattern)
                                                    .Value;
                                            }
                                        }

                                        if (!string.IsNullOrEmpty(component))
                                        {
                                            ExploitdbList.Add(item:
                                                $"{id}:{description}:{component}:{version}"
                                                );
                                        }

                                        Rtx.Invoke((System.Windows.Forms.MethodInvoker)delegate
                                        {
                                            Rtx.Text = (Rtx.Text.Replace(oldValue: Regex.Match(input: Rtx.Text,
                                                pattern: @".*Exploitdb Components.*").Value, newValue: $"[{DateTime.Now.ToString("hh:mm:ss tt")}]\t[+] Exploitdb Components: {ExploitdbList.Count}"));
                                        });
                                    }
                                    catch(Exception ex) { UpdateRtx(txt: $"[-] Error in ExploitID:{ExploitID}.{ex.Message}"); };
                                }
                                lock (sleepLock)
                                {
                                    sleepCounter++;
                                }
                                if (sleepCounter > MaxSleep)
                                {
                                    Thread.Sleep(Timeout);
                                    lock (sleepLock)
                                    {
                                        sleepCounter = 0;
                                    }
                                }
                            }
                        });
                    }
                    catch (AggregateException ex) { UpdateRtx(txt: $"[-] Error description: {ex.Message}"); };

                    UpdateRtx("[+] Database updated from exploit-db.com.");
                    Exploitdb = false;
                    CheckPriority();
                }))
                { IsBackground = true }.Start();
            }
            catch(Exception ex)
            {
                switch(ErrorCode)
                {
                    case 0x1:
                        UpdateRtx(txt: $"[-] Error code: {ErrorCode}");
                        UpdateRtx(txt: $"[-] Error description: Problem in connecting to github server or file not found.{ex.Message}");
                        break;
                    case 0x2:
                        UpdateRtx(txt: $"[-] Error code: {ErrorCode}");
                        UpdateRtx(txt: $"[-] Error description: Problem in reading database.{ex.Message}");
                        break;
                    case 0x3:
                        UpdateRtx(txt: $"[-] Error code: {ErrorCode}");
                        UpdateRtx(txt: $"[-] Error description: Problem in searching component.{ex.Message}\tExploitID:{ExploitID}");
                        break;
                    default:
                        UpdateRtx(txt: $"[-] Error code:Unkown");
                        UpdateRtx(txt: $"[-] Error description: {ex.Message}");
                        break;
                }
            };
            
        }

        private void UpdatePacketstorm()
        {
            string totalExploits;
            int maxPageNumber;
            int[] pageNumbers;
            List<string> linksDatabase = new List<string>();
            try
            {
                new Thread(new ThreadStart(() =>
                {
                    UpdateRtx("[+] Downloading database from packetstormsecurity.com... ");
                    using (WebClient webClient = new WebClient())
                    {
                        ErrorCode = 0x1; // error in connecting to site - parsing page and exploits.
                        webClient.Headers.Add(name: "user-agent",
                            value: " Mozilla/5.0 (Windows NT 6.1; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0");

                        string webpageSource = webClient.DownloadString(address: Packetstorm_Server);
                        maxPageNumber = int.Parse(Regex.Match(input: webpageSource,
                            pattern: Page_Number_Pattern).Value.Split(' ')[3]);
                        pageNumbers = new int[maxPageNumber];                                                   // creating pages number
                        for (int i = 0; i < maxPageNumber; i++)
                        {
                            pageNumbers[i] = i + 1;
                        }

                        totalExploits = Regex.Match(input: webpageSource,
                            pattern: Number_Of_Exploits)
                            .Value.Split(' ')[1];

                        UpdateRtx(txt: $"[+] Found {totalExploits} exploits in {maxPageNumber} pages.");
                        UpdateRtx(txt: $"[+] Reading database...");
                        UpdateRtx(txt: $"[+] Gathering links: 0");
                    }
                    int sleepCounter = 0;
                    object sleepLock = new object();
                    ParallelOptions parallelOptions = new ParallelOptions()
                    {
                        MaxDegreeOfParallelism = Threads
                    };
                    try
                    {
                        Parallel.ForEach(source: pageNumbers.ToList(), parallelOptions: parallelOptions, body: pageNumber =>
                        {
                            ErrorCode = 0x2;
                            string link = Packestorm_Page_Address.Replace(oldValue: "$page",
                                newValue: $"page{pageNumber}");
                            using (WebClient webClient = new WebClient())
                            {
                                webClient.Headers.Add(name: "user-agent",
                                    value: " Mozilla/5.0 (Windows NT 6.1; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0");
                                try
                                {
                                    string webpageSource = webClient.DownloadString(address: link);
                                    foreach (LinkItem i in LinkFinder.Find(file: webpageSource))
                                    {
                                        if (i.ToString().Contains(".html"))
                                        {
                                            if (linksDatabase.IndexOf(item: i.Href) < 0)
                                            {
                                                linksDatabase.Add(i.Href);
                                                Rtx.Invoke((System.Windows.Forms.MethodInvoker)delegate
                                                {
                                                    Rtx.Text = (Rtx.Text.Replace(Regex.Match(input: Rtx.Text,
                                                        pattern: @".*Gathering links.*").Value, newValue: $"[{DateTime.Now.ToString("hh:mm:ss tt")}]\t[+] Gathering links: {linksDatabase.Count}"));
                                                });
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex) { UpdateRtx(txt: $"[-] Error code: {ErrorCode}");UpdateRtx(txt:  $"Error description: Problem in gathering links from page.{ex.Message}"); };
                            }

                            lock (sleepLock)
                            {
                                sleepCounter++;
                            }
                            if (sleepCounter > MaxSleep)
                            {
                                Thread.Sleep(Timeout);
                                lock (sleepLock)
                                {
                                    sleepCounter = 0;
                                }
                            }
                        });

                        UpdateRtx(txt: $"[+] Packetstorm Components: {PacketstormList.Count}");
                        sleepCounter = 0;
                        object rtxLock = new object();

                        Parallel.ForEach(source: linksDatabase.ToList(), parallelOptions: parallelOptions, body: link =>
                        {
                            using (WebClient webClient = new WebClient())
                            {
                                ErrorCode = 0x3; // happens for wrong htmlagility dll version.
                                try
                                {
                                    webClient.Headers.Add(name: "user-agent",
                                        value: " Mozilla/5.0 (Windows NT 6.1; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0");
                                    string webpageSource = webClient.DownloadString(address: $"https://packetstormsecurity.com{link}");
                                    if (Regex.IsMatch(
                                        input: webpageSource,
                                        pattern: Component_Pattern))
                                    {
                                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                                        doc.LoadHtml(html: webpageSource);
                                        var a = doc.DocumentNode.SelectNodes("//h1").Skip(0).Take(1).Single();
                                        string version = "n\a";
                                        if (Regex.IsMatch(
                                            input: webpageSource,
                                            pattern: Date_Pattern))
                                        {
                                            version = versionDetector.GetVersion(Regex.Match(input: webpageSource, pattern: Date_Pattern).Value);
                                        }

                                        lock (rtxLock)
                                        {
                                            PacketstormList.Add($"{link}:{a.InnerText}:{Regex.Match(input: webpageSource, pattern: Component_Pattern).Value}:{version}");
                                            Rtx.Invoke((System.Windows.Forms.MethodInvoker)delegate
                                            {
                                                Rtx.Text = (Rtx.Text.Replace(oldValue: Regex.Match(input: Rtx.Text,
                                                    pattern: @".*Packetstorm Components.*").Value, newValue: $"[{DateTime.Now.ToString("hh:mm:ss tt")}]\t[+] Packetstorm Components: {PacketstormList.Count}"));
                                            });
                                        }

                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (ErrorCode == 0x3)
                                    {
                                        UpdateRtx(txt: $"[-] Error code: {ErrorCode}");
                                        UpdateRtx(txt: $"[-] Error description: Problem in gathering components.{ex.Message}");
                                    }
                                    else
                                    {
                                        UpdateRtx(txt: $"[-] Error code: Unkown");
                                        UpdateRtx(txt: $"[-] Error description: {ex.Message}");
                                    }
                                };
                            }

                            lock (sleepLock)
                            {
                                sleepCounter++;
                            }
                            if (sleepCounter > MaxSleep)
                            {
                                Thread.Sleep(Timeout);
                                lock (sleepLock)
                                {
                                    sleepCounter = 0;
                                }
                            }
                        });

                        UpdateRtx("[+] Database updated from packetstormsecurity.com.");
                        Packetstorm = false;
                        CheckPriority();
                    }
                    catch (AggregateException ex)
                    {
                        UpdateRtx(txt: $"[-] Error code: {ErrorCode}");
                        UpdateRtx(txt: $"[-] Error description: Probably you're using wrong dll version.{ex.Message}");
                    }
                    catch (Exception ex)
                    {

                        UpdateRtx(txt: $"[-] Error code: Unkown");
                        UpdateRtx(txt: $"[-] Error description: {ex.Message}");

                    }
                }))
                { IsBackground = true }.Start();
            }
            catch (Exception ex)
            {
                if (ErrorCode == 0x1)
                {
                    UpdateRtx(txt: $"[-] Error code: {ErrorCode}");
                    UpdateRtx(txt: $"[-] Error description: Problem in connecting to packetstormsecurity.com.{ex.Message}");
                }

                else
                {
                    UpdateRtx(txt: $"[-] Error code: Unkown");
                    UpdateRtx(txt: $"[-] Error description: {ex.Message}");
                }
            }
        }

        private void UpdateJcs()
        {
            using (WebClient webClient = new WebClient())
            {
                UpdateRtx(txt: "[+] Updating database from JCServer...");
                string data = webClient.DownloadString(address: "");
                File.WriteAllText(path: "Databases\\JcsDatabase.txt", contents: data);
                UpdateRtx(txt: "[+] Database updated.");
            }
            CheckPriority();
        }
    }
}
