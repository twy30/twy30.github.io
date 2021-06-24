using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public record Page
    {
        static readonly Dictionary<ReadOnlyCollection<SegmentMarker>, Regex> parserCache = new();

        public string TemplateStart { get; init; }
        public ReadOnlyDictionary<SegmentMarker, string> Data { get; init; }
        public ReadOnlyDictionary<SegmentMarker, string> TemplateEnd { get; init; }

        protected Page(string contents, ReadOnlyCollection<SegmentMarker> markers)
        {
            if (!parserCache.TryGetValue(key: markers, out Regex? parser))
            {
                var patternBuilder = new StringBuilder();
                patternBuilder.Append("^");
                var escapedMarkers = new Dictionary<string, string>();
                AddLazyTemplateParser(start: string.Empty, end: markers[0].Start);
                int lastMarkerIndex = markers.Count - 1;
                const string dataParser = "(.*?)";
                for (var i = 0; i < lastMarkerIndex; ++i)
                {
                    patternBuilder.Append(dataParser);
                    AddLazyTemplateParser(start: markers[i].End, end: markers[i + 1].Start);
                }
                patternBuilder.Append(dataParser);
                AddGreedyTemplateParser(start: markers[lastMarkerIndex].End, end: string.Empty);
                patternBuilder.Append("$");
                parser = new(patternBuilder.ToString(), RegexOptions.CultureInvariant | RegexOptions.Singleline);
                parserCache[markers] = parser;

                void AddLazyTemplateParser(string start, string end) => AddTemplateParser(start, ".*?", end);

                void AddGreedyTemplateParser(string start, string end) => AddTemplateParser(start, ".*", end);

                string GetEscapedMarker(string marker)
                {
                    if (!escapedMarkers.TryGetValue(key: marker, out string? escapedMarker))
                    {
                        escapedMarker = Regex.Escape(marker);
                        escapedMarkers[marker] = escapedMarker;
                    }
                    return escapedMarker;
                }

                void AddTemplateParser(string start, string data, string end) => patternBuilder
                    .Append("(")
                    .Append(GetEscapedMarker(start))
                    .Append(data)
                    .Append(GetEscapedMarker(end))
                    .Append(")");
            }
            var matches = parser.Matches(contents);
            if (matches.Count != 1)
            {
                throw new ArgumentException($"{nameof(contents)} and {nameof(markers)} must uniquely match.");
            }
            var match = matches[0];
            TemplateStart = match.Groups[1].Value;
            var data = new Dictionary<SegmentMarker, string>();
            var templateEnd = new Dictionary<SegmentMarker, string>();
            for (var i = 0; i < markers.Count; ++i)
            {
                var groupIndex = (i + 1) * 2;
                var marker = markers[i];
                data[marker] = match.Groups[groupIndex].Value;
                templateEnd[marker] = match.Groups[groupIndex + 1].Value;
            }
            Data = new(data);
            TemplateEnd = new(templateEnd);
        }
    }
}
