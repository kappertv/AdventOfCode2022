using System;
namespace AdventOfCode2022.Day3
{
	public record Rucksack(string Line)
	{
        public int GetPriority()
        {
            int halflength = Line.Length / 2;
            var left = Line.Take(halflength);
            var right = Line.TakeLast(halflength);
            var common = left.Intersect(right).Distinct().Single();
            return ConvertChar2Prio(common);
        }

        public static int ConvertChar2Prio(char common)
        {
           // Console.WriteLine($"{common} to short {(short)common}");
            if (Char.IsUpper(common))
            {
                return ((short)common) - 38;
            }
            else
            {
                return ((short)common) - 96;
            }
        }
    }
}

