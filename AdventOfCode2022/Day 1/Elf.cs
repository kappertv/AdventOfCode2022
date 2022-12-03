using System;
namespace AdventOfCode2022.Day1
{
	public class Elf
	{
		public Elf()
		{
		}

		public List<Food> Foods = new List<Food>();

		public long GetTotalCalories()
		{
			return Foods.Sum(f => f.Calories);
		}
	}
}

