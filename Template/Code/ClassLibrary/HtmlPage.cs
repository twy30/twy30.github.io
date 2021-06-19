using static ClassLibrary.Statics;
using System.Collections.ObjectModel;

namespace ClassLibrary
{
    public record HtmlPage : Page
    {
        static readonly SegmentMarker HtmlLang = new(
            Start:
                @"<!-- HtmlLang CcBpp/7GB""XMD#c:5eBV,\pX~Ha2W6P7_f,=m}+56 -->" + Newline +
                "<html lang=",
            End:
                ">" + Newline +
                @"<!-- HtmlLang GZuB|*3;H=xg:B'Az2559~A<QK1EQ=;n<=wg,3pB"" -->");

        public static readonly SegmentMarker Title = new(
            Start:
                @"<!-- Title &*Id@2O~~c@j^]<YCh{8/t(DJ1""+ilLm-1q-uvHrc -->" + Newline +
                "    <title>",
            End:
                "</title>" + Newline +
                @"    <!-- Title mKDJo*fWc""c1Iprcy%~UJdWAip)(.h/I%^\Z>zbqm -->");

        public static readonly SegmentMarker MarkdownInput = new(
            Start:
                @"<!-- MarkdownInput XUSmR^t4:hNGdI``s#T)Yt^'tt=)~TS#<JNY3#+v) -->" + Newline +
                @"    <textarea id=""Markdown-input"" cols=""80"" rows=""24"">" + Newline,
            End:
                "    </textarea>" + Newline +
                @"    <!-- MarkdownInput tbDQ17gb%Fv[<K9b7j9Iikei1qIWJ@H32PkobmOby -->");

        public static readonly ReadOnlyCollection<SegmentMarker> Markers = new(new[] {
            HtmlLang,
            Title,
            MarkdownInput });

        public HtmlPage(string contents) : base(contents, Markers) { }
    }
}
