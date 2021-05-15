using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace UpdateIndex
{
    class Program
    {
        static void Main(string[] arguments)
        {
            // Get `workspacePath`, which will be used to figure out
            // other assets' location.
            var workspacePath = string.Empty;
            workspacePath = arguments.GetArgument(index: 0, nameof(workspacePath));

            // Get `indexSegmentMarkers`, which will be used to build
            // `index.html`.
            var indexSegmentMarkers = ImmutableArray.Create(
                new SegmentMarker(
                    Start: "\n<!-- <TableOfContents> -->\n",
                    End: "\n<!-- </TableOfContents> -->\n"));

            // Get `indexTemplate`, which will be used to build
            // `index.html`.
            var indexTemplate = default(Template);
            var indexPath = Path.Combine(workspacePath, "index.html");
            {
                var contents = File.ReadAllText(indexPath);
                indexTemplate = new Template(contents, indexSegmentMarkers);
            }

            // Update `index.html`.
            {
                var indexBuilder = new StringBuilder();
                const int beforeTableOfContents = 0;
                indexBuilder.Append(indexTemplate.Segments[beforeTableOfContents]);
                // Build the table of contents.
                {
                    var pagesPath = Path.Combine(workspacePath, "Pages");
                    var pagePaths = Directory.EnumerateFiles(pagesPath, searchPattern: "*.html", SearchOption.AllDirectories);
                    foreach (var path in pagePaths.OrderBy(_ => _))
                    {
                        var contents = File.ReadAllText(path);
                        var page = new Page(contents, UpdatePages.Program.pageSegmentMarkers);
                        const int titleSegment = 1;
                        indexBuilder.AppendFormat(
                            "* [{0}]({1})",
                            page.Segments[titleSegment],
                            path.Substring(path.IndexOfEnd(workspacePath, startIndex: 0)));
                        indexBuilder.AppendLine();
                    }
                }
                const int afterTableOfContents = 1;
                indexBuilder.Append(indexTemplate.Segments[afterTableOfContents]);

                File.WriteAllText(indexPath, indexBuilder.ToString());
            }
        }
    }
}
