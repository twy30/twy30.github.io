using System;

namespace ClassLibrary
{
    public static class Statics
    {
        public const string _404_html = "404.html";
        public const string CopyMe_html = "CopyMe.html";
        public const string htmlSearchPattern = "*.html";
        public const string index_html = "index.html";
        public const string Newline = "\n";
        public const string Pages = "Pages";
        public const string Template = "Template";

        public static string GetArgument(this string[] arguments, int index, string name)
        {
            if (arguments.Length <= index)
            {
                throw new ArgumentException($"{nameof(arguments)}[{index}] `{name}` must be specified.");
            }
            return arguments[index];
        }
    }
}
