using static ClassLibrary.Statics;
using ClassLibrary;
using System.Collections.ObjectModel;

namespace UpdateIndex
{
    record IndexPage : Page
    {
        public static readonly SegmentMarker TableOfContents = new(
            Start: @"<!-- TableOfContents }<N#JA0{zK8GAhFqg,i-j8Sb}TA""zdzz\N]rQ^{yA -->" + Newline,
            End: @"<!-- TableOfContents j?17mGiiN35qa{N""RcQ~fx4J@<V3C&cjmdi0N&tKl -->");

        static readonly ReadOnlyCollection<SegmentMarker> markers = new(new[] { TableOfContents });

        public IndexPage(string contents) : base(contents, markers) { }
    }
}
