using static ClassLibrary.Statics;
using ClassLibrary;
using System.IO;
using System.Text;

namespace UpdateTitles
{
    class Program
    {
        static void Main(string[] arguments)
        {
            var workspacePath = string.Empty;
            workspacePath = arguments.GetArgument(index: 0, nameof(workspacePath));
            var pagePaths = Directory.EnumerateFiles(
                Path.Combine(workspacePath, Pages),
                htmlSearchPattern,
                SearchOption.AllDirectories);
            foreach (var path in pagePaths)
            {
                var pageContents = File.ReadAllText(path);
                var htmlPage = new HtmlPage(pageContents);
                var title = htmlPage.Data[HtmlPage.Title];
                var markdownPage = new MarkdownPage(pageContents);
                var contentsBuilder = new StringBuilder();
                contentsBuilder.Append(markdownPage.TemplateStart);
                contentsBuilder.Append(title);
                contentsBuilder.Append(markdownPage.TemplateEnd[MarkdownPage.Title]);
                File.WriteAllText(path, contentsBuilder.ToString());
            }
        }
    }
}
