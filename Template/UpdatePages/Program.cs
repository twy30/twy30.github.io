using System;
using System.Collections.Immutable;
using System.IO;
using System.Text;

namespace UpdatePages
{
    static class Program
    {
        static void Main(string[] arguments)
        {
            // Get `workspacePath`, which will be used to figure out
            // other assets' locations.
            var workspacePath = string.Empty;
            {
                const int argumentIndex = 0;
                if (arguments.Length <= argumentIndex)
                {
                    throw new ArgumentException(
                        $"{nameof(arguments)}[{argumentIndex}] `{nameof(workspacePath)}` must be specified.",
                        nameof(arguments));
                }
                workspacePath = arguments[argumentIndex];
            }

            // Get `template`, which will be used to update various
            // "pages".
            var template = default(PageTemplate);
            {
                var templatePath = Path.Combine(workspacePath, "Template", "CopyMe.html");
                var templateString = File.ReadAllText(templatePath);
                template = new PageTemplate(templateString);
            }

            // Update `index.html`.
            {
                var indexPath = Path.Combine(workspacePath, "index.html");
                Update(indexPath);
            }

            // Update `Pages/*.html`.
            {
                var pagesPath = Path.Combine(workspacePath, "Pages");
                var pagePaths = Directory.EnumerateFiles(
                    pagesPath,
                    "*.html",
                    SearchOption.AllDirectories);
                foreach (var pagePath in pagePaths)
                {
                    Update(pagePath);
                }
            }

            void Update(string pagePath)
            {
                var pageString = File.ReadAllText(pagePath);
                var page = new Page(pageString);

                var pageBuilder = new StringBuilder();
                var i = 0;
                for (; i < page.Segments.Length; ++i)
                {
                    pageBuilder.Append(template.Segments[i]);
                    pageBuilder.Append(page.Segments[i]);
                }
                pageBuilder.Append(template.Segments[i]);

                File.WriteAllText(pagePath, pageBuilder.ToString());
            }
        }

        record PageTemplate
        {
            public ImmutableArray<string> Segments { get; init; }

            public PageTemplate(string templateString)
            {
                var segmentsBuilder = ImmutableArray.CreateBuilder<string>(segmentMarkers.Length + 1);
                var startIndex = 0;
                foreach (var marker in segmentMarkers)
                {
                    var segment = new StringSegment(
                        templateString,
                        startIndex,
                        templateString.IndexOfEnd(marker.Start, startIndex));
                    segmentsBuilder.Add(segment.ToString());
                    startIndex = templateString.IndexOf(marker.End, segment.End, StringComparison.Ordinal);
                }
                segmentsBuilder.Add(templateString.Substring(startIndex));
                Segments = segmentsBuilder.ToImmutable();
            }
        }

        record SegmentMarker(string Start, string End);

        static ImmutableArray<SegmentMarker> segmentMarkers = ImmutableArray.Create(
            new SegmentMarker(
                "\n<html lang=",
                ">\n\n<head>\n"),
            new SegmentMarker(
                "\n    <title>",
                "</title>\n"),
            new SegmentMarker(
                "\n    <textarea id=\"Markdown-input\" cols=\"80\" rows=\"24\">\n",
                "\n    </textarea>\n    <div id=\"HTML-output\"></div>\n"));

        record StringSegment
        {
            public string StringValue { get; init; }
            /// <summary>
            /// Gets the inclusive start index.
            /// </summary>
            public int Start { get; init; }
            /// <summary>
            /// Gets the exclusive end index.
            /// </summary>
            public int End { get; init; }

            public StringSegment(string stringValue, int start, int end)
            {
                ThrowIfInvalid(start);
                ThrowIfInvalid(end);
                if (end < start)
                {
                    throw new ArgumentException($"{nameof(end)} `{end}` must not be less than {nameof(start)} `{start}`.", nameof(end));
                }
                if (stringValue.Length < end)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(end),
                        end,
                        $"{nameof(end)} must not be greater than {nameof(stringValue)}.{nameof(stringValue.Length)} `{stringValue.Length}`.");
                }

                StringValue = stringValue;
                Start = start;
                End = end;

                static void ThrowIfInvalid(int index)
                {
                    if (index < 0)
                    {
                        throw new ArgumentOutOfRangeException(
                            nameof(index),
                            index,
                            $"{nameof(index)} must not be less than 0.");
                    }
                }
            }

            public override string ToString() => StringValue.Substring(Start, End - Start);
        }

        record Page
        {
            public ImmutableArray<string> Segments { get; init; }

            public Page(string pageString)
            {
                var segmentsBuilder = ImmutableArray.CreateBuilder<string>(segmentMarkers.Length);
                var startIndex = 0;
                foreach (var marker in segmentMarkers)
                {
                    startIndex = pageString.IndexOfEnd(marker.Start, startIndex);
                    var segment = new StringSegment(
                        pageString,
                        startIndex,
                        pageString.IndexOf(marker.End, startIndex, StringComparison.Ordinal));
                    segmentsBuilder.Add(segment.ToString());
                    startIndex = segment.End + marker.End.Length;
                }
                Segments = segmentsBuilder.ToImmutable();
            }
        }
    }

    static class StaticMethods
    {
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
