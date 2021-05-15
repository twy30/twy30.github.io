using System;

namespace ClassLibrary
{
    public static class StaticMethods
    {
        public static string GetArgument(this string[] arguments, int index, string name)
        {
            if (arguments.Length <= index)
            {
                throw new ArgumentException($"{nameof(arguments)}[{index}] `{name}` must be specified.");
            }
            return arguments[index];
        }

        public static int IndexOfEnd(this string stringValue, string marker, int startIndex)
        {
            var index = stringValue.IndexOf(marker, startIndex);
            if (index < 0)
            {
                return index;
            }
            return index + marker.Length;
        }
    }
}
