using ClassLibrary;
using System.Collections.ObjectModel;

namespace UpdateIndex
{
    record IndexPage : Page
    {
        public static readonly SegmentMarker TableOfContents = new(
            Start: "\n<!-- <TableOfContents> -->\n",
            End: "\n<!-- </TableOfContents> -->\n");

        static readonly ReadOnlyCollection<SegmentMarker> markers = new(new[] { TableOfContents });

        public IndexPage(string contents) : base(contents, markers) { }
    }
}
