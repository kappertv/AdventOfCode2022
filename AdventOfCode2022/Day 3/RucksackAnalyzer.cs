using System;
namespace AdventOfCode2022.Day3
{
	public class RucksackAnalyzer
	{
		public RucksackAnalyzer(string[] lines)
		{
            foreach (var line in lines)
            {
                rucksacks.Add(new Rucksack(line));
            }
		}

        List<Rucksack> rucksacks = new List<Rucksack>();

        public long GetTotalPriorities()
        {
            return rucksacks.Sum(r => r.GetPriority());
        }

        public long GetTotalBatchPriority()
        {
            var groupsOfThree = new List<List<Rucksack>>();
            for (int i = 0;i < rucksacks.ToArray().Length; i += 3)
            {
                var groupOfThree = new List<Rucksack>(rucksacks.Take(new Range(i, i + 3)));
                groupsOfThree.Add(groupOfThree);
            }

            var result = 0;
            foreach (var batch in groupsOfThree)
            {
                var lines = batch.Select(s => s.Line).ToArray();
                var common = lines[0].Intersect(lines[1]).Intersect(lines[2]).Distinct().Single();
                result += Rucksack.ConvertChar2Prio(common);
            }
            return result;         
        }
    }
}

