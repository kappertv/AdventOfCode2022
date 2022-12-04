using System;
using AdventOfCode2022.Day4;
using Shouldly;

namespace tests.Day4
{
	[TestClass]
	public class CampCleanUpTests
	{
		[TestMethod]
		public void GetFullOverlappingAssignmentPairsSample()
		{
			var analyzer = new CampCleanup(File.ReadAllLines("Day 4//sampleinput.txt"));
			analyzer.GetOverlappingPairs().ShouldBe(5);
        }

        [TestMethod]
        public void GetFullOverlappingAssignmentPairs()
        {
            var analyzer = new CampCleanup(File.ReadAllLines("Day 4//input.txt"));
            analyzer.GetOverlappingPairs().ShouldBe(556);
        }

        [TestMethod]
        public void GetPairsWithSomeOverlappingAssignmentPairs()
        {
            var analyzer = new CampCleanup(File.ReadAllLines("Day 4//input.txt"));
            analyzer.GetABitOverlappingPairs().ShouldBe(876);
        }

        [TestMethod]
        public void GetPairsWithSomeOverlappingAssignmentPairsSample()
        {
            var analyzer = new CampCleanup(File.ReadAllLines("Day 4//sampleinput.txt"));
            analyzer.GetABitOverlappingPairs().ShouldBe(9);
        }

        //19-54,18-53 -- yes
        //1-73,1-73 -- yes
        //17-34,18-34 -- yes
        //93-93,25-94 -- yes
        //96-98,7-95 -- no
        //58-97,73-98 -- yes
        //7-64,8-64 -- yes
        //87-91,67-90 -- yes
        //42-78,77-85 -- yes
        //24-96,24-97 -- yes
    }
}

