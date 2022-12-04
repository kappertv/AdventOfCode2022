namespace AdventOfCode2022.Day4;

public class CampCleanup {
    List<AssignmentPair> assignmentPairs = new List<AssignmentPair>();
		public CampCleanup(string[] lines)
		{
        foreach (var line in lines)
        {
            var parts = line.Split(",");
            var pair = new AssignmentPair(
                GetRangeFromString(parts[0]),
                GetRangeFromString(parts[1]));
            assignmentPairs.Add(pair);
        }
    }

    private static SectionRange GetRangeFromString(string linepart)
    {
        var x = linepart.Split("-");
        return new SectionRange(int.Parse(x[0]), int.Parse(x[1]));
    }

    public long GetABitOverlappingPairs()
    {
        return assignmentPairs.Count(ap => ap.IsOverlapped());
    }

    public long GetOverlappingPairs()
    {
        return assignmentPairs.Count(ap => ap.IsFullyOverlapped());
    }
}

