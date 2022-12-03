using System;
namespace AdventOfCode2022.Day1
{
	public record Elf(List<Food> Foods)
	{
		public long GetTotalCalories()
		{
			return Foods.Sum(f => f.Calories);
		}
	}
}

