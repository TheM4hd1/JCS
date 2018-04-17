using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace JCS_1._0.Utilities
{
    static class Helper
    {
        public static bool ContainsHtmlTag(this string text, string tag)
        {
            var pattern = @"<\s*" + tag + @"\s*\/?>";
            return Regex.IsMatch(text, pattern, RegexOptions.IgnoreCase);
        }

        public static bool ContainsHtmlTags(this string text, string tags)
        {
            var ba = tags.Split('|').Select(x => new { tag = x, hastag = text.ContainsHtmlTag(x) }).Where(x => x.hastag);

            return ba.Count() > 0;
        }

        public static string FixUrl(string url)
        {
            if (!(url.StartsWith("http://") || url.StartsWith("https://")))
            {
                url = $"http://{url}";
            }

            if (url.Contains("://www."))
            {
                url = url.Replace("www.", "");
            }

            if (url.EndsWith("/"))
            {
                url = url.Remove(url.Length - 1);
            }
            return url;
        }
    }
}
