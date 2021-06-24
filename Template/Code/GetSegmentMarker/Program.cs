using ClassLibrary;
using System;
using System.Text;

namespace GetSegmentMarker
{
    class Program
    {
        static void Main(string[] arguments)
        {
            var segmentName = string.Empty;
            const int segmentNameArgumentIndex = 0;
            segmentName = arguments.GetArgument(segmentNameArgumentIndex, name: nameof(segmentName));
            if (ContainsIllegalHtmlCommentString(segmentName, out var illegalHtmlCommentString))
            {
                throw new ArgumentException(
                    $"`{nameof(segmentName)}` contains illegal HTML comment string: `{illegalHtmlCommentString}`.",
                    $"{nameof(arguments)}[{segmentNameArgumentIndex}])");
            }

            // 94 printable ASCII characters from `U+0021` (exclamation
            // mark `!`) to `U+007E` (tilde `~`).
            const string idCharacters = @"!""#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~";

            // const double EddingtonNumber = 1e80; // https://en.wikipedia.org/wiki/Eddington_number
            // var idLength = (int)Math.Ceiling(Math.Log(EddingtonNumber, idCharacters.Length));
            const int idLength = 41;

            var random = new Random();
            var idBuilder = new StringBuilder(idLength);
            var segmentID = string.Empty;
            do
            {
                while (idBuilder.Length < idLength)
                {
                    idBuilder.Append(idCharacters[random.Next(idCharacters.Length)]);
                }
                segmentID = idBuilder.ToString();
                if (!ContainsIllegalHtmlCommentString(segmentID, out _))
                {
                    break;
                }
                idBuilder.Clear();
            } while (true);

            const string segmentMarkerStart = "<!--";
            const string segmentMarkerEnd = "-->";
            const string segmentMarkerSeparator = " ";
            var segmentMarker = new StringBuilder(
                segmentMarkerStart.Length
                + segmentMarkerSeparator.Length
                + segmentName.Length
                + segmentMarkerSeparator.Length
                + segmentID.Length
                + segmentMarkerSeparator.Length
                + segmentMarkerEnd.Length)
                .Append(segmentMarkerStart)
                .Append(segmentMarkerSeparator)
                .Append(segmentName)
                .Append(segmentMarkerSeparator)
                .Append(segmentID)
                .Append(segmentMarkerSeparator)
                .Append(segmentMarkerEnd)
                .ToString();
            Console.WriteLine(segmentMarker);

            static bool ContainsIllegalHtmlCommentString(string str, out string illegalHtmlCommentString)
            {
                // https://www.w3.org/TR/2021/SPSD-html52-20210128/syntax.html#comments
                var illegalHtmlCommentStrings = new[] { "<!--", "-->", "--!>" };
                for (var i = 0; i < illegalHtmlCommentStrings.Length; ++i)
                {
                    illegalHtmlCommentString = illegalHtmlCommentStrings[i];
                    if (str.Contains(illegalHtmlCommentString, StringComparison.Ordinal))
                    {
                        return true;
                    }
                }
                illegalHtmlCommentString = string.Empty;
                return false;
            }
        }
    }
}
