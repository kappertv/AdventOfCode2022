namespace AdventOfCode2022.Day1;
public class ElfAnalyzer
{
    public ElfAnalyzer(string[] lines)
    {
        ReadLines(lines);
    }

    private void ReadLines(string[] lines)
    {
        var foods = new List<Food>();
        foreach (var line in lines)
        {
            line.Trim();
            if (line.Equals(String.Empty))
            {
                elves.Add(new Elf(foods));
                foods = new List<Food>();
            }
            else
            {
                int calories = int.Parse(line);
                foods.Add(new Food(calories));
            }
        }
        elves.Add(new Elf(foods));
    }

    private List<Elf> elves = new List<Elf>();

    public long GetElveWithMostCalories()
    {
        return elves.Max(e => e.GetTotalCalories());
    }

    public long GetTopThreeElvesMostCalories()
    {
        var orderedElves = elves.OrderByDescending(e => e.GetTotalCalories());
        return orderedElves.Take(3).Sum(o => o.GetTotalCalories());
    }
}

