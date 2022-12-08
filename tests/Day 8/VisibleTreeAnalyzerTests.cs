using System;
using AdventOfCode2022.Day8;
using Shouldly;

namespace tests.Day8
{
    [TestClass]
    public class VisibleTreeAnalyzerTests
    {
        [TestMethod]
        public void GetVisibleTreesOfSample()
        {
            var analyzer = new VisibleTreeAnalyzer(File.ReadAllLines("Day 8//sampleinput.txt"));
            analyzer.GetNumberOfVisibleTree().ShouldBe(21);
        }

        [TestMethod]
        public void GetVisibleTreesOfInput()
        {
            var analyzer = new VisibleTreeAnalyzer(File.ReadAllLines("Day 8//input.txt"));
            analyzer.GetNumberOfVisibleTree().ShouldBe(1690);
        }

        [TestMethod]
        public void GetHighestScenicScoreTreesOfSample()
        {
            var analyzer = new VisibleTreeAnalyzer(File.ReadAllLines("Day 8//sampleinput.txt"));
            analyzer.GetTreeWithHighestScenicScore().ShouldBe(8);
        }

        [TestMethod]
        public void GetHighestScenicScoreTreesOfInput()
        {
            var analyzer = new VisibleTreeAnalyzer(File.ReadAllLines("Day 8//input.txt"));
            analyzer.GetTreeWithHighestScenicScore().ShouldBe(535680);
        }
    }
}

