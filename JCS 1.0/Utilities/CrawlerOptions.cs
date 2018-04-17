using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCS_1._0.Utilities
{
    static class CrawlerOptions
    {
        public static string RegexPattern { get => regexPattern; set => regexPattern = value; }
        static string regexPattern = @"(com_)\w*[A-Za-z0-9\-]\w+";

        public static string BlackList { get => blackList; set => blackList = value; }
        static string blackList = @"*.js,*.css,*.gif,*.jpg,*.jpeg,*.jpe,*.bmp,*.png,*.swf,*.zip,*.rar,*.tar,*.gz,*.tgz,*.exe,*.pdf,*.doc,*.docx,*.mp3,*.wma,*.waw,*.mpg,*.mp4,*.mpeg,*.avi,*mov,*qt,*.wmv,*.gif,*.jpg,*.jpeg,*.jpe,*.bmp,*.png,*.tif";

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

        public static List<string> ReturnBlackList()
        {
            List<string> extentions = new List<string>();

            foreach(string s in BlackList.Split(separator: ','))
            {
                try
                {
                    extentions.Add(item: s.Split(separator: '.')[1]);
                }
                catch { };
            }

            return extentions;
        }
    }
}
