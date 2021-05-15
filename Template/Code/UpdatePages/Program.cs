using System.Collections.Immutable;
using System.IO;
using System.Text;
using ClassLibrary;

namespace UpdatePages
{
    public class Program
    {
        public static readonly ImmutableArray<SegmentMarker> pageSegmentMarkers = ImmutableArray.Create(
            new SegmentMarker(
                Start: "\n<html lang=",
                End: ">\n\n<head>\n"),
            new SegmentMarker(
                Start: "\n    <title>",
                End: "</title>\n"),
            new SegmentMarker(
                Start: "\n    <textarea id=\"Markdown-input\" cols=\"80\" rows=\"24\">\n",
                End: "\n    </textarea>\n    <div id=\"HTML-output\"></div>\n"));

        static void Main(string[] arguments)
        {
            // Get `workspacePath`, which will be used to figure out
            // other assets' location.
            var workspacePath = string.Empty;
            workspacePath = arguments.GetArgument(index: 0, nameof(workspacePath));

            // Get `template`, which will be used to build 
            // `Pages/*.html`.
            var pageTemplate = default(Template);
            {
                var path = Path.Combine(workspacePath, "Template", "CopyMe.html");
                var contents = File.ReadAllText(path);
                pageTemplate = new Template(contents, pageSegmentMarkers);
            }

            // Update `index.html`.
            {
                var path = Path.Combine(workspacePath, "index.html");
                Update(path);
            }

            // Update `Pages/*.html`.
            {
                var pagesPath = Path.Combine(workspacePath, "Pages");
                var pagePaths = Directory.EnumerateFiles(pagesPath, searchPattern: "*.html", SearchOption.AllDirectories);
                foreach (var path in pagePaths)
                {
                    Update(path);
                }
            }

            void Update(string path)
            {
                var contents = File.ReadAllText(path);
                var page = new Page(contents, pageSegmentMarkers);

                var pageBuilder = new StringBuilder();
                var i = 0;
                for (; i < page.Segments.Length; ++i)
                {
                    pageBuilder.Append(pageTemplate.Segments[i]);
                    pageBuilder.Append(page.Segments[i]);
                }
                pageBuilder.Append(pageTemplate.Segments[i]);

                File.WriteAllText(path, pageBuilder.ToString());
            }
        }
    }
}
