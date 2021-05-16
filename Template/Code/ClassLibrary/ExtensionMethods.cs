using System;

namespace ClassLibrary
{
    public static class ExtensionMethods
    {
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
