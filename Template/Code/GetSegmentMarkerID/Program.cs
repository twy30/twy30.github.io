using System;
using System.Linq;
using System.Text;

namespace GetSegmentMarkerID
{
    class Program
    {
        static void Main()
        {
            var idCharacters = GetIDCharacters();
            var idLength = GetIDLength(idCharacters);

            var random = new Random();
            var id = string.Empty;
            do
            {
                var idBuilder = new StringBuilder(idLength);
                while (idBuilder.Length < idLength)
                {
                    idBuilder.Append(idCharacters[random.Next(idCharacters.Length)]);
                }
                id = idBuilder.ToString();
            } while (!IsHtmlCommentCompatible(id));

            Console.WriteLine(id);

            static char[] GetIDCharacters()
            {
                const char ExclamationMark = '!'; // U+0021
                const char Tilde = '~';           // U+007E
                return Enumerable
                    .Range(ExclamationMark, Tilde - ExclamationMark + 1)
                    .Select(_ => (char)_)
                    .ToArray();
            }

            static int GetIDLength(char[] idCharacters)
            {
                var EddingtonNumber = 1e80; // https://en.wikipedia.org/wiki/Eddington_number
                var idCharacterTypeCount = idCharacters.ToHashSet().Count;
                return (int)Math.Ceiling(Math.Log(EddingtonNumber, idCharacterTypeCount));
            }

            // https://www.w3.org/TR/2021/SPSD-html52-20210128/syntax.html#comments
            static bool IsHtmlCommentCompatible(string id)
            {
                if (id.StartsWith(">", StringComparison.Ordinal)) { return false; }
                if (id.StartsWith("->", StringComparison.Ordinal)) { return false; }
                if (id.Contains("<!--", StringComparison.Ordinal)) { return false; }
                if (id.Contains("-->", StringComparison.Ordinal)) { return false; }
                if (id.Contains("--!>", StringComparison.Ordinal)) { return false; }
                if (id.EndsWith("<!-", StringComparison.Ordinal)) { return false; }
                return true;
            }
        }
    }
}
