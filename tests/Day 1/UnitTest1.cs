using AdventOfCode2022.Day1;
using Shouldly;

namespace tests;

[TestClass]
public class UnitTest1
{
    ElfAnalyzer _sut;

    [TestInitialize]
    public void Initialize()
    {
        var line = File.ReadAllLines("Day 1//input.txt");
        _sut = new ElfAnalyzer(line);
    }

    [TestMethod]
    public void GetElveWithMostCalories()
    {
        _sut.GetElveWithMostCalories().ShouldBe(69795);
    }

    [TestMethod]
    public void GetTopThreeElves()
    {
        _sut.GetTopThreeElvesMostCalories().ShouldBe(208437);
    }
}
