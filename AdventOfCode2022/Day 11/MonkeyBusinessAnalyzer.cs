using System;
namespace AdventOfCode2022.Day11
{
    public class MonkeyBusinessAnalyzer
    {
        List<Monkey> monkeys = new List<Monkey>();
        public MonkeyBusinessAnalyzer(string[] lines)
        {
            for (var i = 0; i < lines.Length; i += 7)
            {
                var nr = GetMonkeyNr(lines[i]);
                var startingitems = GetStartingItems(lines[i + 1]);
                var operation = GetIncreasedWorryLevelFunction(lines[i + 2]);
                var test = GetThrowToMonkey(lines[i + 3], lines[i + 4], lines[i + 5]);
            }
        }

        private Func<int, int> GetThrowToMonkey(string test, string trueMonkey, string falseMonkey)
        {

            throw new NotImplementedException();
        }

        private Func<int> GetIncreasedWorryLevelFunction(string v)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<int> GetStartingItems(string line)
        {
            var items = line.Substring("Starting items:".Count()).Split(",").Select(s => s.Trim()).Select(s => int.Parse(s));
            return items;
        }

        private static int GetMonkeyNr(string line)
        {
            if (line.StartsWith("Monkey")) throw new InvalidProgramException();
            return int.Parse(line.ElementAt(7).ToString());
        }
    }
}

