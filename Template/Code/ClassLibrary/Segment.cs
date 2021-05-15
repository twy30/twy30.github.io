using System;

namespace ClassLibrary
{
    record Segment
    {
        string Data { get; init; }
        /// <summary>
        /// Gets the inclusive start index.
        /// </summary>
        int Start { get; init; }
        /// <summary>
        /// Gets the exclusive end index.
        /// </summary>
        public int End { get; init; }

        public Segment(string data, int start, int end)
        {
            ThrowIfInvalid(start);
            if (end < start)
            {
                throw new ArgumentException(
                    $"{nameof(start)} `{start}` must not be greater than {nameof(end)} `{end}`.",
                    nameof(end));
            }
            ThrowIfInvalid(end);
            if (data.Length < end)
            {
                throw new ArgumentException(
                    $"{nameof(end)} must not be greater than {nameof(data)}.{nameof(data.Length)} `{data.Length}`.",
                    nameof(end));
            }

            Data = data;
            Start = start;
            End = end;

            static void ThrowIfInvalid(int index)
            {
                if (index < 0)
                {
                    throw new ArgumentException(
                        $"{nameof(index)} must not be less than 0.",
                        nameof(index));
                }
            }
        }

        public override string ToString() => Data.Substring(Start, End - Start);
    }
}
