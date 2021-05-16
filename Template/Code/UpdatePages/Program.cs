using static ClassLibrary.HtmlPage;
using static ClassLibrary.Statics;
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
            var template = new HtmlPage(contents: File.ReadAllText(Path.Combine(workspacePath, Template, CopyMe_html)));
            Update(Path.Combine(workspacePath, index_html));

            var pagePaths = Directory.EnumerateFiles(
                Path.Combine(workspacePath, Pages),
                htmlSearchPattern,
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
                foreach (var marker in Markers)
                {
                    contentsBuilder.Append(page.Data[marker]);
                    contentsBuilder.Append(template.TemplateEnd[marker]);
                }
                File.WriteAllText(path, contentsBuilder.ToString());
            }
        }
    }
}
