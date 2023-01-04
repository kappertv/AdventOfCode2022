using System;
using AdventOfCode2022.Day9;
using Shouldly;

namespace tests.Day9;
[TestClass]
public class RopeBridgeAnalyzerTests
{
    [TestMethod]
    public void GetAtLeaseOnceVisitedPositionsByTailForSampleInput()
    {
        var analyzer = new RopeBridgeAnalyzer(File.ReadAllLines("Day 9//sampleinput.txt"));
        analyzer.GetOnceVisitedPositionsByTail().Count(i => i > 0).ShouldBe(13);
    }

    [TestMethod]
    public void CheckRangesWithSampleInput()
    {
        var analyzer = new RopeBridgeAnalyzer(File.ReadAllLines("Day 9//sampleinput.txt"));
        analyzer.GetRangeX().ShouldBe((1, 6));
        analyzer.GetRangeY().ShouldBe((1, 5));
    }

    [TestMethod]
    public void GetMapOfOnceVisitedPositionsByTailForSampleInput()
    {
        var expected = new string[] {
            "..##..",
            "...##.",
            ".####.",
            "....#.",
            "####.." };

        var analyzer = new RopeBridgeAnalyzer(File.ReadAllLines("Day 9//sampleinput.txt"));
        var actual = analyzer.GetOnceVisitedPositionsByTailVisualization();
        actual.ShouldBe(expected);
    }

    [TestMethod]
    public void GetRangesForInput()
    {
        var analyzer = new RopeBridgeAnalyzer(File.ReadAllLines("Day 9//input.txt"));
        analyzer.GetRangeX().ShouldBe((-136, 191)); // 327
        analyzer.GetRangeY().ShouldBe((-476, 79)); // 555
        // pos 137,477
    }


    [TestMethod]
    public void GetAtLeaseOnceVisitedPositionsByTailForInput()
    {
        var analyzer = new RopeBridgeAnalyzer(File.ReadAllLines("Day 9//input.txt"));
        analyzer.GetOnceVisitedPositionsByTail().Count(i => i > 0).ShouldBe(6642);
        // to high 6643.
        //edwin oplossing 6642.
    }
}