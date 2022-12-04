using System;
namespace AdventOfCode2022.Day4
{
	public record AssignmentPair(Range rangeone, Range rangetwo) {

		public bool IsFullyOverlapped()
		{
			return rangeone.FullyOverlaps(rangetwo) || rangetwo.FullyOverlaps(rangeone);
        }

        public bool IsOverlapped()
        {
            return rangeone.Overlaps(rangetwo);
        }
    }

	public static class Extensions
	{
        public static bool FullyOverlaps(this Range one, Range two)
        {
            return
                one.Start.Value <= two.Start.Value &&
                one.End.Value >= two.End.Value &&
                two.Start.Value <= one.End.Value;
        }

        public static bool Overlaps(this Range one, Range two)
        {
            return
                one.End.Value >= two.Start.Value &&
                one.Start.Value <= two.End.Value;
        }
    }

}

