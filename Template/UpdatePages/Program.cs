using System;
using System.IO;
using System.Text;
using static UpdatePages.StaticMethods;

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
                const int index = 0;
                if (arguments.Length <= index)
                {
                    throw new ArgumentException($"Missing {nameof(arguments)}[{index}]: {nameof(workspacePath)}", nameof(arguments));
                }
                workspacePath = arguments[index];
            }

            // Get `template`, which will be used to update various
            // "pages".
            var templatePath = Path.Combine(workspacePath, "Template", "CopyMe.html");
            var templateString = File.ReadAllText(templatePath);
            var template = new PageTemplate(templateString);

            // Update `index.html`.
            var indexPath = Path.Combine(workspacePath, "index.html");
            Update(indexPath, template);

            // Update `Pages/*.html`.
            var pagesPath = Path.Combine(workspacePath, "Pages");
            foreach (var pagePath in Directory.EnumerateFiles(pagesPath, "*.html", SearchOption.AllDirectories))
            {
                Update(pagePath, template);
            }
        }

        record PageTemplate
        {
            public string BeforeTitle { get; init; }
            public string AfterTitle_BeforeTextarea { get; init; }
            public string AfterTextarea { get; init; }

            public PageTemplate(string templateString)
            {
                var index = 0;
                var beforeTitle = new StringSegment(
                    templateString,
                    index,
                    templateString.IndexOfEnd(titleMarker.Start, index));
                BeforeTitle = beforeTitle.ToString();
                index = templateString.IndexOf(titleMarker.End, beforeTitle.End, StringComparison.Ordinal);
                var afterTitleBeforeTextarea = new StringSegment(
                    templateString,
                    index,
                    templateString.IndexOfEnd(textareaMarker.Start, index));
                AfterTitle_BeforeTextarea = afterTitleBeforeTextarea.ToString();
                var afterTextarea = new StringSegment(
                    templateString,
                    templateString.IndexOf(textareaMarker.End, afterTitleBeforeTextarea.End, StringComparison.Ordinal),
                    templateString.Length);
                AfterTextarea = afterTextarea.ToString();
            }
        }

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
                    throw new ArgumentOutOfRangeException(nameof(end), end, $"{nameof(end)} must not be greater than {nameof(stringValue)}.{nameof(stringValue.Length)} `{stringValue.Length}`.");
                }

                StringValue = stringValue;
                Start = start;
                End = end;
            }

            public override string ToString() => StringValue.Substring(Start, End - Start);
        }

        record StringMarker(string Start, string End);

        static readonly StringMarker titleMarker = new(
            "<title>",
            "</title>");
        static readonly StringMarker textareaMarker = new(
            "<textarea id=\"Markdown-input\" cols=\"80\" rows=\"24\">\n",
            "\n    </textarea>\n    <div id=\"HTML-output\"></div>");

        static void Update(string pagePath, PageTemplate pageTemplate)
        {
            var pageString = File.ReadAllText(pagePath);
            var page = new Page(pageString);
            var updatedPageString = new StringBuilder()
                .Append(pageTemplate.BeforeTitle)
                .Append(page.Title)
                .Append(pageTemplate.AfterTitle_BeforeTextarea)
                .Append(page.Textarea)
                .Append(pageTemplate.AfterTextarea)
                .ToString();
            File.WriteAllText(pagePath, updatedPageString);
        }

        class Page
        {
            public string Title { get; init; }
            public string Textarea { get; init; }

            public Page(string pageString)
            {
                var index = pageString.IndexOfEnd(titleMarker.Start, 0);
                var title = new StringSegment(
                    pageString,
                    index,
                    pageString.IndexOf(titleMarker.End, index, StringComparison.Ordinal));
                Title = title.ToString();
                index = pageString.IndexOfEnd(textareaMarker.Start, title.End);
                var textArea = new StringSegment(
                    pageString,
                    index,
                    pageString.IndexOf(textareaMarker.End, index, StringComparison.Ordinal));
                Textarea = textArea.ToString();
            }
        }
    }

    static class StaticMethods
    {
        public static int IndexOfEnd(this string stringValue, string marker, int startIndex)
        {
            var index = stringValue.IndexOf(marker, startIndex);
            ThrowIfInvalid(index);
            return index + marker.Length;
        }

        public static void ThrowIfInvalid(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, $"{nameof(index)} must not be less than 0.");
            }
        }
    }
}
