using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ClassLibrary
{
    public record Template
    {
        public ImmutableArray<string> Segments { get; init; }

        public Template(string contents, IEnumerable<SegmentMarker> markers)
        {
            var segmentsBuilder = ImmutableArray.CreateBuilder<string>();
            var segmentStartIndex = 0;
            foreach (var marker in markers)
            {
                int segmentEndIndex = contents.IndexOfEnd(marker.Start, segmentStartIndex);
                var segment = new Segment(contents, segmentStartIndex, segmentEndIndex);
                segmentsBuilder.Add(segment.ToString());
                segmentStartIndex = contents.IndexOf(marker.End, segment.End, StringComparison.Ordinal);
            }
            segmentsBuilder.Add(contents.Substring(segmentStartIndex));
            Segments = segmentsBuilder.ToImmutable();
        }
    }
}
