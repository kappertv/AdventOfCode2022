using System;
using AdventOfCode2022.Day3;
using Shouldly;

namespace tests.Day3
{
	[TestClass]
	public class RucksackAnalyzerTests
	{
		[TestMethod]
		public void TestSampleInputRucksack()
		{
			var lines = File.ReadAllLines("Day 3//sampleinput.txt");
			var analyzer = new RucksackAnalyzer(lines);
			analyzer.GetTotalPriorities().ShouldBe(157);
		}

        [TestMethod]
        public void TestSampleInputRucksackBatch()
        {
            var lines = File.ReadAllLines("Day 3//sampleinput.txt");
            var analyzer = new RucksackAnalyzer(lines);
            analyzer.GetTotalBatchPriority().ShouldBe(70);
        }

        [TestMethod]
        public void TestInputRucksack()
        {
            var lines = File.ReadAllLines("Day 3//input.txt");
            var analyzer = new RucksackAnalyzer(lines);
            analyzer.GetTotalPriorities().ShouldBe(7553);
        }

        [TestMethod]
        public void TestInputRucksackBatch()
        {
            var lines = File.ReadAllLines("Day 3//input.txt");
            var analyzer = new RucksackAnalyzer(lines);
            analyzer.GetTotalBatchPriority().ShouldBe(2758);
        }
    }
}

