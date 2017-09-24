using System.Text.RegularExpressions;

namespace DealerOn.Helpers
{
    public static class RegexHelper
    {
        public static string InputRegexString = @"(\d+)\s?(\b[\w\s]+\b)*\s?(at)\s?(\d+\.\d+)";
        public static Regex InputRegex = new Regex(InputRegexString, RegexOptions.IgnoreCase);
    }
}