using System;
using HtmlAgilityPack;
using JCS_1._0.Http;
using System.Text;
using System.Threading;
using System.Net.Http;
using System.Net;
using System.Text.RegularExpressions;

namespace JCS_1._0.Http
{
    // Joomla Version Scanner
    class VersionScanner:TargetSettings
    {
        #region vars
        public string Version { get => version; set => version = value; }
        string version;

        #endregion
        
        public VersionScanner()
        {
            TargetSettings targetSettings = new TargetSettings();
        }
        public string Scan()
        {
            try
            {
                version = "undetected";
                if (MethodXML(HttpClient))
                    return Version;

                else if (MethodReadMe(HttpClient))
                    return Version;

                else if (MethodTinyMCE(HttpClient))
                    return Version;

                else if (MethodMetaDataXML(HttpClient))
                    return Version;
                else
                    return Version;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        bool MethodXML(HttpClient hc)
        {
            //administrator/manifests/files/joomla.xml
            HttpResponseMessage response = hc.GetAsync(requestUri: $"{Url}/administrator/manifests/files/joomla.xml").Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html: response.Content.ReadAsStringAsync().Result);
                foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//version"))
                {
                    if (Regex.IsMatch(input: node.InnerText, pattern: @"[\d]+([\.]?)+([\d]?)+([\.]?)+([\d]?)"))
                    {
                        Version = node.InnerText;
                        return true;
                    }
                }
            }
            return false;
        }
        bool MethodReadMe(HttpClient hc)
        {
            HttpResponseMessage respones = hc.GetAsync(requestUri: $"{Url}/README.txt").Result;
            string result = respones.Content.ReadAsStringAsync().Result;

            if ((int)respones.StatusCode == 200)
            {
                // Joomla! xx.xx.xx version
                if (Regex.IsMatch(input: result, pattern: @"(Joomla! )+[\d]+([\.]?)+([\d]?)+([\.]?)+([\d]?)+( version)"))
                {
                    Version = Regex.Match(input: result, pattern: @"(Joomla! )+[\d]+([\.]?)+([\d]?)+([\.]?)+([\d]?)+( version)").Value;
                    return true;
                }
            }

            return false;
        }
        bool MethodTinyMCE(HttpClient hc)
        {
            HttpResponseMessage response = hc.GetAsync(requestUri: $"{Url}/plugins/editors/tinymce/tinymce.xml").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html: response.Content.ReadAsStringAsync().Result);
                foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//version"))
                {
                    if (Regex.IsMatch(input: node.InnerText, pattern: @"[\d]+([\.]?)+([\d]?)+([\.]?)+([\d]?)"))
                    {
                        switch (node.InnerText)
                        {
                            case "3.3.9.3":
                                Version = "1.6.0 - 1.6.6";
                                return true;
                            case "3.4.3.2":
                                Version = "1.7.0";
                                return true;
                            case "3.4.4":
                                Version = "1.7.1 - 1.7.5";
                                return true;
                            case "3.4.7":
                                Version = "2.5.0 - 2.5.3";
                                return true;
                            case "3.4.9":
                                Version = "2.5.4";
                                return true;
                            case "3.5.2":
                                Version = "2.5.5 - 2.5.6";
                                return true;
                            case "3.5.4.1":
                                Version = "2.5.7 - 2.5.27";
                                return true;
                            case "3.5.11":
                                Version = "2.5.28";
                                return true;
                            case "3.5.6":
                                Version = "3.0.0 - 3.1.6";
                                return true;
                            case "4.0.10":
                                Version = "3.2.0 - 3.2.1";
                                return true;
                            case "4.0.12":
                                Version = "3.2.2";
                                return true;
                            case "4.0.18":
                                Version = "3.2.3 - 3.2.4";
                                return true;
                            case "4.0.22":
                                Version = "3.3.0";
                                return true;
                            case "4.0.28":
                                Version = "3.3.1 - 3.3.6";
                                return true;
                            case "4.1.7":
                                Version = "3.4.0 - 3.4.8";
                                return true;
                            case "4.3.3":
                                Version = "3.5.0 - 3.5.1";
                                return true;
                            case "4.3.12":
                                Version = "3.6.0";
                                return true;
                            case "4.4.0":
                                Version = "3.6.1 - 3.6.2";
                                return true;
                            case "4.4.3":
                                Version = "3.6.3 - 3.6.5";
                                return true;
                            case "4.5.6":
                                Version = "3.7.0 - 3.7.2";
                                return true;
                            case "4.5.7":
                                Version = "3.7.3 - 3.8.0";
                                return true;
                            default:
                                Version = "Unkown version";
                                return false;
                        }
                    }
                }
            }
            return false;
        }
        bool MethodMetaDataXML(HttpClient hc)
        {
            HttpResponseMessage response = hc.GetAsync(requestUri: $"{Url}/components/com_contact/metadata.xml").Result;
            string result = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                if (result.Contains("8178 2007-07-23 05:39:47Z eddieajau"))
                {
                    Version = "1.5.0 - 1.5.18";
                    return true;
                }

                if (result.Contains("17437 2010-06-01 14:35:04Z pasamio"))
                {
                    Version = "1.5.19 - 1.5.26";
                    return true;
                }
            }

            return false;
        }
    }
}
