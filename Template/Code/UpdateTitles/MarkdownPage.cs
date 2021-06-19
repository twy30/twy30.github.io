using static ClassLibrary.Statics;
using ClassLibrary;
using System.Collections.ObjectModel;

namespace UpdateTitles
{
    record MarkdownPage : Page
    {
        public static readonly SegmentMarker Title = new(
            Start:
                HtmlPage.MarkdownInput.Start +
                "# ",
            End:
                Newline +
                Newline);

        static readonly ReadOnlyCollection<SegmentMarker> markers = new(new[] { Title });

        public MarkdownPage(string contents) : base(contents, markers) { }
    }
}
