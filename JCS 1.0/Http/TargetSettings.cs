using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace JCS_1._0.Http
{
    class TargetSettings
    {
        public string Url { get => url; set => url = value; }
        string url;

        public HttpClient HttpClient { get => httpClient; set => httpClient = value; }
        private HttpClient httpClient;

        public HttpClientHandler HttpHandler { get => httpHandler; set => httpHandler = value; }
        private HttpClientHandler httpHandler;

        public int Threads { get => threads; set => threads = value; }
        int threads = Environment.ProcessorCount;

        public int TimeOut { get => timeOut; set => timeOut = value; }
        int timeOut = 100;

        public TargetSettings()
        {
            HttpHandler = new HttpClientHandler()
            {
                AllowAutoRedirect = true
            };
            HttpClient = new HttpClient(HttpHandler);
            
            if (HttpOptions.IsHttpOptions)
            {
                if (HttpOptions.IsProxy)
                {
                    if (HttpOptions.IsProxyAuthentication)
                    {
                        string[] creds = HttpOptions.ProxyCredentials.Split(':');
                        ICredentials credentials = new NetworkCredential(creds[0], creds[1]);
                        HttpHandler = new HttpClientHandler()
                        {
                            UseProxy = true,
                            Proxy = new WebProxy(HttpOptions.ProxyFullAddress, true, null, credentials),
                            AllowAutoRedirect = false
                        };
                    }
                    else
                    {
                        HttpHandler = new HttpClientHandler()
                        {
                            UseProxy = true,
                            Proxy = new WebProxy(HttpOptions.ProxyFullAddress),
                            AllowAutoRedirect = false
                        };
                    }
                    HttpClient = new HttpClient(HttpHandler);
                }

                if (HttpOptions.IsAuthentication)
                {
                    if (HttpOptions.AuthenticationType.Equals("Basic"))
                    {
                        var byteArray = Encoding.ASCII.GetBytes(s: HttpOptions.Credentials);
                        HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        scheme: "Basic", parameter: Convert.ToBase64String(byteArray));
                    }
                    else if (HttpOptions.AuthenticationType.Equals("Digest"))
                    {
                        Uri uri = new Uri(Url);
                        var credentialCache = new CredentialCache
                        {
                            {
                                new Uri(uri.GetLeftPart(UriPartial.Authority)), // request url's host
                                "Digest",  // authentication type 
                                new NetworkCredential(HttpOptions.Credentials.Split(':')[0], HttpOptions.Credentials.Split(':')[1]) // credentials 
                            }
                        };

                        HttpHandler.Credentials = credentialCache;
                        HttpClient = new HttpClient(HttpHandler);
                    }
                }

                if (HttpOptions.IsHttpHeaders)
                {
                    foreach (string header in HttpOptions.HttpHeaders.Keys)
                        HttpClient.DefaultRequestHeaders.Add(header, HttpOptions.HttpHeaders[header]);
                }
            }

            if (string.IsNullOrEmpty(HttpOptions.HttpUserAgent))
                HttpClient.DefaultRequestHeaders.Add(name: "user-agent", value: " Mozilla/5.0 (Windows NT 6.1; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0");
            else
                HttpClient.DefaultRequestHeaders.Add("user-agent", HttpOptions.HttpUserAgent);
        }

    }
}
