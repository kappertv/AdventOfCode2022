using System;
using AdventOfCode2022.Day7;
using Shouldly;

namespace tests.Day7
{
    [TestClass]
    public class FolderSizeAnalyzerTests
    {
        [TestMethod]
        public void GetFolderSizeOfSample()
        {
            var analyzer = new FolderSizeAnalyzer(System.IO.File.ReadAllLines("Day 7//sampleinput.txt"));
            analyzer.GetSumOfFoldersWithAtMost(100000).ShouldBe(95437);
        }

        [TestMethod]
        public void GetFolderSizeOfInput()
        {
            var analyzer = new FolderSizeAnalyzer(System.IO.File.ReadAllLines("Day 7//input.txt"));
            analyzer.GetSumOfFoldersWithAtMost(100000).ShouldBe(1297683);
        }

        [TestMethod]
        public void GetSmallestFolderSizeOfSample()
        {
            var analyzer = new FolderSizeAnalyzer(System.IO.File.ReadAllLines("Day 7//sampleinput.txt"));
            analyzer.GetSmallestFolderToReachRequiredSpace().ShouldBe(24933642);
        }

        [TestMethod]
        public void GetSmallestFolderSizeOfInput()
        {
            var analyzer = new FolderSizeAnalyzer(System.IO.File.ReadAllLines("Day 7//input.txt"));
            analyzer.GetSmallestFolderToReachRequiredSpace().ShouldBe(5756764L);
        }
        
    }
}

