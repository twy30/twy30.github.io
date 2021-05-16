using static ClassLibrary.HtmlPage;
using ClassLibrary;
using System.IO;
using System.Text;

namespace UpdatePages
{
    public class Program
    {
        static void Main(string[] arguments)
        {
            var workspacePath = string.Empty;
            workspacePath = arguments.GetArgument(index: 0, nameof(workspacePath));
            var template = new HtmlPage(contents: File.ReadAllText(Path.Combine(workspacePath, "Template", "CopyMe.html")));
            Update(Path.Combine(workspacePath, "index.html"));

            var pagePaths = Directory.EnumerateFiles(
                Path.Combine(workspacePath, "Pages"),
                searchPattern: "*.html",
                SearchOption.AllDirectories);
            foreach (var path in pagePaths)
            {
                Update(path);
            }

            void Update(string path)
            {
                var contentsBuilder = new StringBuilder();
                contentsBuilder.Append(template.TemplateStart);
                var page = new HtmlPage(contents: File.ReadAllText(path));
                for (var i = 0; i < Markers.Count; ++i)
                {
                    contentsBuilder.Append(page.Data[Markers[i]]);
                    contentsBuilder.Append(template.TemplateEnd[Markers[i]]);
                }
                File.WriteAllText(path, contentsBuilder.ToString());
            }
        }
    }
}
