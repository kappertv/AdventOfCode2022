using System;
using Day5.AdventOfCode2022;
using Shouldly;

namespace tests.Day5
{
    [TestClass]
    public class SupplyStackAnalyzerTests
    {
        [TestMethod]
        public void GetMessageForSampleInput()
        {
            var analyzer = new SupplyStackAnalyzer(File.ReadAllLines("Day 5//sampleinput.txt"));
            analyzer.GetMessage().ShouldBe("CMZ");
        }

        [TestMethod]
        public void GetMessageForInput()
        {
            var analyzer = new SupplyStackAnalyzer(File.ReadAllLines("Day 5//input.txt"));
            analyzer.GetMessage().ShouldBe("LBLVVTVLP");
        }

        [TestMethod]
        public void GetMessagePart2ForSampleInput()
        {
            var analyzer = new SupplyStackAnalyzer(File.ReadAllLines("Day 5//sampleinput.txt"));
            analyzer.GetMessagePart2().ShouldBe("MCD");
        }

        [TestMethod]
        public void GetMessagePart2ForInput()
        {
            var analyzer = new SupplyStackAnalyzer(File.ReadAllLines("Day 5//input.txt"));
            analyzer.GetMessagePart2().ShouldBe("TPFFBDRJD");
        }
    }
}

