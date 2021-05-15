using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ClassLibrary
{
    public record Page
    {
        public ImmutableArray<string> Segments { get; init; }

        public Page(string contents, IEnumerable<SegmentMarker> markers)
        {
            var segmentsBuilder = ImmutableArray.CreateBuilder<string>();
            var segmentStartIndex = 0;
            foreach (var marker in markers)
            {
                segmentStartIndex = contents.IndexOfEnd(marker.Start, segmentStartIndex);
                var segmentEndIndex = contents.IndexOf(marker.End, segmentStartIndex, StringComparison.Ordinal);
                var segment = new Segment(contents, segmentStartIndex, segmentEndIndex);
                segmentsBuilder.Add(segment.ToString());
                segmentStartIndex = segment.End + marker.End.Length;
            }
            Segments = segmentsBuilder.ToImmutable();
        }
    }
}
