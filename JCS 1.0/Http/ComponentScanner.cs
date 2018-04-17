using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using JCS_1._0.Utilities;
using System.Text.RegularExpressions;
using System.Net;

namespace JCS_1._0.Http
{
    class ComponentScanner:TargetSettings
    {
        #region V A R S
        public string JoomlaVersion { get => joomlaVersion; set => joomlaVersion = value; }
        string joomlaVersion;
        public System.Windows.Forms.RichTextBox Rtx;
        public System.Windows.Forms.ProgressBar Prg;
        public System.Windows.Forms.ListView Lvw;
        public System.Windows.Forms.Label Lbl;
        List<Databases.DatabaseItems> components;
        double JVersion;
        int CheckedComponents;
        public int MaxChecked;
        object CheckedLock = new object();
#endregion
        public ComponentScanner()
        {
            TargetSettings targetSettings = new TargetSettings();
            components = new List<Databases.DatabaseItems>();
            CheckedComponents = 0;
        }

        private void UpdateRtx(string txt)
        {
            Rtx.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                Rtx.AppendText(text: $"[{DateTime.Now.ToString("hh:mm:ss tt")}]\t{txt}\n");
            });
        }

        public void Scan()
        {
            new Thread(new ThreadStart(() =>
            {
                ReadDatabase();
                UpdateRtx(txt: $"[+] Joomla version: {JoomlaVersion}");
                
                if(JoomlaVersion.Equals(value: "undetected"))
                {
                    UpdateRtx(txt: "[-] It's not possible to scan components based on target's version.");
                    UpdateRtx(txt: "[-] Scanning all components...");
                }
                else
                {
                    UpdateRtx(txt: "[+] Scanning components based on target's version...");
                    double.TryParse(s: $"{JoomlaVersion.Split('.')[0]}.{JoomlaVersion.Split('.')[1]}",
                                result: out JVersion);
                }
                ParallelOptions parallelOptions = new ParallelOptions()
                {
                    MaxDegreeOfParallelism = Threads
                };
                Parallel.ForEach(source: components, parallelOptions: parallelOptions, body: item =>
                {
                    lock (CheckedLock)
                    {
                        CheckedComponents++;
                        Prg.Invoke(method: (System.Windows.Forms.MethodInvoker)delegate
                        {
                            Prg.Value = CalculatePercentage();
                            Lbl.Invoke(method: (System.Windows.Forms.MethodInvoker)delegate
                            {
                                Lbl.Text = $"{Prg.Value}%";
                            });
                        });

                        if(CheckedComponents % MaxChecked == 0)
                        {
                            Thread.Sleep(TimeOut);
                        }
                    }

                    if(!JoomlaVersion.Equals(value: "undetected"))
                    {
                        double.TryParse(s: item.version, result: out double componentVersion);
                        if (JVersion >= 1 && JVersion <= 2.5)
                        {
                            if (componentVersion >= 1.0 && componentVersion <= 2.5)
                            {
                                {
                                    Task scanComponent = new Task(() =>
                                    {
                                        CheckComponentVulnerablity(item);
                                    });
                                    scanComponent.Start();
                                    scanComponent.Wait();
                                } // scan
                            }
                        }

                        else if (JVersion == 2.5)
                        {
                            if (componentVersion >= 2.5 && componentVersion <= 3.5)
                            {
                                {
                                    Task scanComponent = new Task(() =>
                                    {
                                        CheckComponentVulnerablity(item);
                                    });
                                    scanComponent.Start();
                                    scanComponent.Wait();
                                } // scan
                            }
                        }

                        else //(JVersion >= 3.0)
                        {
                            if (componentVersion >= 2.5 && componentVersion <= 3.8)
                            {
                                {
                                    Task scanComponent = new Task(() =>
                                    {
                                        CheckComponentVulnerablity(item);
                                    });
                                    scanComponent.Start();
                                    scanComponent.Wait();
                                } // scan
                            }
                        }
                    }
                    else 
                    {
                        {
                            Task scanComponent = new Task(() =>
                            {
                                CheckComponentVulnerablity(item);
                            });
                            scanComponent.Start();
                            scanComponent.Wait();
                        } //scan
                    } //undetected version
                });

                UpdateRtx(txt: $"[+] Scan finished.");
            }))
            {
                IsBackground = true
            }.Start();
            
        }

        private bool ReadDatabase()
        {
            UpdateRtx(txt: $"[+] Checking for databases...");
            try
            {
                if (File.Exists(path: "Databases\\database.txt"))
                {
                    UpdateRtx(txt: $"[+] 'database.txt' file found.");
                    using (StreamReader streamReader = new StreamReader(path: "Databases\\database.txt"))
                    {
                        string data = streamReader.ReadToEnd();
                        components = JsonConvert.DeserializeObject<List<Databases.DatabaseItems>>(value: data);
                    }
                }

                if (File.Exists(path: "Databases\\JcsDatabase.txt"))
                {
                    UpdateRtx(txt: $"[+] 'JcsDatabase.txt' file found.");
                    using (StreamReader streamReader = new StreamReader(path: "Databases\\JcsDatabase.txt"))
                    {
                        string data = streamReader.ReadToEnd();
                        components = components.Concat(JsonConvert.DeserializeObject<List<Databases.DatabaseItems>>(value: data)).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateRtx(txt: $"[-] Error in reading database.");
                UpdateRtx(txt: $"[-] Error description: {ex.Message}");
                return false;
            }
            UpdateRtx(txt: $"[+] Database items: {components.Count}");
            return true;
        }

        private int CalculatePercentage()
        {
            return ((CheckedComponents * 100) / components.Count);
        }

        private void CheckComponentVulnerablity(Databases.DatabaseItems item)
        {
            try
            {
                string url = $"{Url}/components/{item.component}";
                HttpResponseMessage httpResponse = HttpClient.GetAsync(requestUri: url).Result;
                HttpContent httpContent = httpResponse.Content;
                string result = httpContent.ReadAsStringAsync().Result;

                if (IdentificationOptions.IsIdentificationOptions)
                {
                    bool isNextStepAvailable = true;
                    if (IdentificationOptions.IsHttpStatusCode)
                    {
                        bool continueScan = false;
                        string[] statusCodes = IdentificationOptions.HttpStatusCode.Split('|');

                        for (int i = 0; i < statusCodes.Length - 1; i++)
                        {
                            if ((int)httpResponse.StatusCode == int.Parse(statusCodes[i]))
                            {
                                continueScan = true;
                                break;
                            }
                        }

                        if (!continueScan)
                        {
                            isNextStepAvailable = false;
                        }
                    }

                    if (IdentificationOptions.IsHtmlTags)
                    {
                        if (isNextStepAvailable)
                        {
                            if (result.ContainsHtmlTags(tags: IdentificationOptions.HtmlTags))
                            {
                                isNextStepAvailable = false;
                            }
                        }
                    }

                    if (IdentificationOptions.IsPageCompare)
                    {
                        if (isNextStepAvailable)
                        {
                            if (!result.Contains(value: IdentificationOptions.PageCompare))
                            {
                                isNextStepAvailable = false;
                            }
                        }
                    }

                    if (IdentificationOptions.IsRegexPattern)
                    {
                        bool continueScan = false;
                        if (isNextStepAvailable)
                        {
                            continueScan = Regex.IsMatch(input: result, pattern: IdentificationOptions.RegexPattern);
                            if (!continueScan)
                            {
                                isNextStepAvailable = false;
                            }
                        }
                    }

                    if (isNextStepAvailable)
                    {
                        InsertData(item, CheckExploit(s: item.exploit));
                    } // insert data
                } // custom options

                else
                {
                    if (httpResponse.StatusCode != HttpStatusCode.NotFound && httpResponse.StatusCode != HttpStatusCode.Redirect)
                    {
                        if (result.Contains(value: "<html><body bgcolor=\"#FFFFFF\"></body></html>") ||
                            result.Contains(value: "<!DOCTYPE html><title></title>"))
                        {
                            InsertData(item, CheckExploit(s: item.exploit));
                        }
                    }
                } // default options
            }
            catch(Exception ex)
            {
                UpdateRtx(txt: $"[-] Error description: {ex.Message}");
            }
        }

        private bool CheckExploit(string s)
        {
            try
            {
                if (!string.IsNullOrEmpty(value: s))
                {
                    HttpResponseMessage exploitResponse = HttpClient.GetAsync(requestUri: $"{Url}/${s}").Result;
                    if (exploitResponse.IsSuccessStatusCode ||
                       exploitResponse.StatusCode == HttpStatusCode.Moved)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                UpdateRtx(txt: $"[-] Error description: {ex.Message}");
                return false;
            }
        }

        private void InsertData(Databases.DatabaseItems item,bool exploitChecked)
        {
            Lvw.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                System.Windows.Forms.ListViewItem lvi = new System.Windows.Forms.ListViewItem
                {
                    Text = (Lvw.Items.Count + 1).ToString(),
                    Checked = exploitChecked
                };
                lvi.SubItems.Add(item.description);
                lvi.SubItems.Add($"{item.component} - {item.version}");
                if (item.id.Contains("files"))
                    lvi.SubItems.Add($"https://packetstormsecurity.com{item.id}");
                else
                    lvi.SubItems.Add($"https://www.exploit-db.com/exploits/{item.id}");

                Lvw.Items.Add(lvi);
            });
        }
    }
}
