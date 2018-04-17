using System;

namespace JCS_1._0.Utilities
{
    static class IdentificationOptions
    {
        public static bool IsIdentificationOptions { get => isIdentificationOptions; set => isIdentificationOptions = value; }
        private static bool isIdentificationOptions;

        public static string HtmlTags { get => htmlTags; set => htmlTags = value; }
        private static string htmlTags;

        public static bool IsHtmlTags { get => isHtmlTags; set => isHtmlTags = value; }
        private static bool isHtmlTags;

        public static string HttpStatusCode { get => httpStatusCode; set => httpStatusCode = value; }
        private static string httpStatusCode;

        public static bool IsHttpStatusCode { get => isHttpStatusCode; set => isHttpStatusCode = value; }
        private static bool isHttpStatusCode;

        public static string RegexPattern { get => regexPattern; set => regexPattern = value; }
        private static string regexPattern;

        public static bool IsRegexPattern { get => isRegexPattern; set => isRegexPattern = value; }
        private static bool isRegexPattern;

        public static string PageCompare { get => pageCompare; set => pageCompare = value; }
        private static string pageCompare;

        public static bool IsPageCompare { get => isPageCompare; set => isPageCompare = value; }
        private static bool isPageCompare;

        public static bool IsValidRegex()
        {
            if (string.IsNullOrEmpty(RegexPattern)) return false;

            try
            {
                System.Text.RegularExpressions.Regex.Match("", RegexPattern);
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }
    }
}
