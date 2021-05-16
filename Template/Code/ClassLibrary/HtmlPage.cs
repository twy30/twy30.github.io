using System.Collections.ObjectModel;

namespace ClassLibrary
{
    public record HtmlPage : Page
    {
        static readonly SegmentMarker HtmlLang = new(
            Start: "\n<html lang=",
            End: ">\n\n<head>\n");

        public static readonly SegmentMarker Title = new(
            Start: "\n    <title>",
            End: "</title>\n");

        static readonly SegmentMarker MarkdownInput = new(
            Start: "\n    <textarea id=\"Markdown-input\" cols=\"80\" rows=\"24\">\n",
            End: "\n    </textarea>\n    <div id=\"HTML-output\"></div>\n");

        public static readonly ReadOnlyCollection<SegmentMarker> Markers = new(new[] {
            HtmlLang,
            Title,
            MarkdownInput });

        public HtmlPage(string contents) : base(contents, Markers) { }
    }
}
