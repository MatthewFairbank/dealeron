using System;

namespace DealerOn.Helpers
{
    public static class StringHelper
    {
        public static string[] SplitByNewLine(string input)
        {
            return input?.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }
    }
}