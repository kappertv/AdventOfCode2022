using System;
using AdventOfCode2022.Day1;
using AdventOfCode2022.Day2;
using Shouldly;

namespace tests.Day2
{
	[TestClass]
	public class RockPaperScissorTests
	{
		[TestMethod]
		public void TestSampleInput()
		{
            var analyzer = new RockPaperScissorStrategyAnalyzer(File.ReadAllLines("Day 2//sampleinput.txt"));

            analyzer.GetScore().ShouldBe(15);
		}

        [TestMethod]
        public void TestSampleInputPart2()
        {
            var analyzer = new RockPaperScissorStrategyAnalyzer(File.ReadAllLines("Day 2//sampleinput.txt"));

            analyzer.GetScorePart2().ShouldBe(12);
        }

        // Rock defeats Scissors, Scissors defeats Paper, and Paper defeats Rock. 

        [TestMethod]
		public void TestAXScore()
		{
			new RockPaperScissorStrategyAnalyzer(new[] { "A X" }).GetScore().ShouldBe(3 + 1);
		}

        [TestMethod]
        public void TestAYScore()
        {
            new RockPaperScissorStrategyAnalyzer(new[] { "A Y" }).GetScore().ShouldBe(6 + 2);
        }

        [TestMethod]
        public void TestAZScore()
        {
            new RockPaperScissorStrategyAnalyzer(new[] { "A Z" }).GetScore().ShouldBe(0 + 3);
        }

        [TestMethod]
        public void TestBXScore()
        {
            new RockPaperScissorStrategyAnalyzer(new[] { "B X" }).GetScore().ShouldBe(0 + 1);
        }

        [TestMethod]
        public void TestBYScore()
        {
            new RockPaperScissorStrategyAnalyzer(new[] { "B Y" }).GetScore().ShouldBe(3 + 2);
        }

        [TestMethod]
        public void TestBZScore()
        {
            new RockPaperScissorStrategyAnalyzer(new[] { "B Z" }).GetScore().ShouldBe(6 + 3);
        }

        [TestMethod]
        public void TestCXcore()
        {
            new RockPaperScissorStrategyAnalyzer(new[] { "C X" }).GetScore().ShouldBe(6 + 1);
        }

        [TestMethod]
        public void TestCYcore()
        {
            new RockPaperScissorStrategyAnalyzer(new[] { "C Y" }).GetScore().ShouldBe(0 + 2);
        }

        [TestMethod]
        public void TestCZcore()
        {
            new RockPaperScissorStrategyAnalyzer(new[] { "C Z" }).GetScore().ShouldBe(3 + 3);
        }

        [TestMethod]
        public void TestFirst10()
        {
            var analyzer = new RockPaperScissorStrategyAnalyzer(File.ReadAllLines("Day 2//input.txt").Take(10).ToArray());
            analyzer.GetScore().ShouldBe(51);
        }

        [TestMethod]
		public void GetInputResult()
		{
			var analyzer = new RockPaperScissorStrategyAnalyzer(File.ReadAllLines("Day 2//input.txt"));
			analyzer.GetScore().ShouldBe(12772);
		}

        [TestMethod]
        public void GetInputResultPart2()
        {
            var analyzer = new RockPaperScissorStrategyAnalyzer(File.ReadAllLines("Day 2//input.txt"));
            analyzer.GetScorePart2().ShouldBe(11618);
        }
    }
}

