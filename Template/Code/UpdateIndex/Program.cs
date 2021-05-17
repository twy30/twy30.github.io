using static ClassLibrary.HtmlPage;
using static ClassLibrary.Statics;
using static UpdateIndex.IndexPage;
using ClassLibrary;
using System.IO;
using System.Linq;
using System.Text;

namespace UpdateIndex
{
    class Program
    {
        static void Main(string[] arguments)
        {
            var workspacePath = string.Empty;
            workspacePath = arguments.GetArgument(index: 0, name: nameof(workspacePath));
            var contentsBuilder = new StringBuilder();
            var indexPath = Path.Combine(workspacePath, index_html);
            var indexPage = new IndexPage(contents: File.ReadAllText(indexPath));
            contentsBuilder.Append(indexPage.TemplateStart);
            var tocBuilder = new StringBuilder(); // toc: Table of Contents
            var pagePaths = Directory.EnumerateFiles(
                Path.Combine(workspacePath, Pages),
                htmlSearchPattern,
                SearchOption.AllDirectories);
            foreach (var path in pagePaths.OrderBy(_ => _))
            {
                var page = new HtmlPage(contents: File.ReadAllText(path));
                var title = page.Data[Title];
                var link = path.Substring(workspacePath.Length);
                tocBuilder.AppendFormat(format: "* [{0}]({1})", title, link);
                tocBuilder.AppendLine();
            }
            contentsBuilder.Append(tocBuilder.ToString());
            contentsBuilder.Append(indexPage.TemplateEnd[TableOfContents]);
            File.WriteAllText(indexPath, contentsBuilder.ToString());
        }
    }
}
