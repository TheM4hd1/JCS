using System.Collections.Generic;

namespace JCS_1._0.Http
{
    static class HttpOptions
    {
        public static bool IsHttpOptions { get => isHttpOptions; set => isHttpOptions = value; }
        private static bool isHttpOptions;

        public static bool IsAuthentication { get => isAuthentication; set => isAuthentication = value; }
        private static bool isAuthentication = false;

        public static string Credentials { get => credentials; set => credentials = value; }
        private static string credentials;
        public static string AuthenticationType { get => authenticationType; set => authenticationType = value; }
        private static string authenticationType;

        public static bool IsProxy { get => isProxy; set => isProxy = value; }
        private static bool isProxy = false;

        public static string ProxyFullAddress { get => proxyFullAddress; set => proxyFullAddress = value; }
        private static string proxyFullAddress;

        public static bool IsProxyAuthentication { get => isProxyAuthentication; set => isProxyAuthentication = value; }
        private static bool isProxyAuthentication;

        public static string ProxyCredentials { get => proxyCredentials; set => proxyCredentials = value; }
        private static string proxyCredentials;

        public static string HttpUserAgent { get => httpUserAgent; set => httpUserAgent = value; }
        private static string httpUserAgent;

        public static bool IsHttpHeaders { get => isHttpHeaders; set => isHttpHeaders = value; }
        private static bool isHttpHeaders;

        public static Dictionary<string, string> HttpHeaders { get => httpHeaders; set => httpHeaders = value; }
        private static Dictionary<string, string> httpHeaders;
    }
}
