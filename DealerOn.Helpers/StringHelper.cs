using System;

namespace DealerOn.Helpers
{
    public static class StringHelper
    {
        public static string[] SplitByNewLine(string input)
        {
            return input?.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        public static decimal ConvertColToDecimal(string value)
        {
            return decimal.TryParse(value, out var output) ? output : 0;
        }

        public static bool ConvertColToBool(string value)
        {
            bool.TryParse(value, out var output);
            return output;
        }
    }
}