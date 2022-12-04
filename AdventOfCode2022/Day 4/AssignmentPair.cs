namespace AdventOfCode2022.Day4;

public record AssignmentPair(SectionRange rangeone, SectionRange rangetwo) {

    public bool IsFullyOverlapped()
    {
        return rangeone.FullyOverlaps(rangetwo) || rangetwo.FullyOverlaps(rangeone);
    }

    public bool IsOverlapped()
    {
        return rangeone.Overlaps(rangetwo);
    }
}

public static class Extensions {
    public static bool FullyOverlaps(this SectionRange one, SectionRange two)
    {
        return
            (one.Start >= two.Start &&
             one.End <= two.End);
    }

    public static bool Overlaps(this SectionRange one, SectionRange two)
    {
        return
            one.End >= two.Start &&
            one.Start <= two.End;
    }
}

