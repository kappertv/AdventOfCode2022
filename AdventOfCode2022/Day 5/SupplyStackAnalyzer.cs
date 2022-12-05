using System;
namespace Day5.AdventOfCode2022
{
    public class SupplyStackAnalyzer
    {
        Dictionary<int, Stack<char>> stacksOfCrates = new Dictionary<int, Stack<char>>();
        List<string> crateLines = new List<string>();
        List<Instruction> instructions = new List<Instruction>();
        public SupplyStackAnalyzer(string[] lines)
        {
            foreach (var line in lines)
            {
                if (line.ContainsCrates())
                {
                    crateLines.Add(line);
                }

                if (line.ContainsInstruction())
                {
                    var parts = line.Split(" ", StringSplitOptions.TrimEntries);
                    instructions.Add(new Instruction(
                        int.Parse(parts[1]), int.Parse(parts[3]), int.Parse(parts[5])));
                }
            }
            ProcessCrateLines(crateLines);
        }

        private void ProcessInstructions(bool orderretained)
        {
            foreach (var instruction in instructions)
            {
                if (orderretained)
                {
                    ProcessInstructionOrderRetained(instruction);
                }
                else
                {
                    ProcessInstruction(instruction);
                }
            }
        }

        private void ProcessInstructionOrderRetained(Instruction instruction)
        {
            List<char> crates = new List<char>();
            Stack<char> from = stacksOfCrates[instruction.from];
            for (int i = 0; i < instruction.quantity; i++)
            {
                crates.Add(from.Pop());
            }
            Stack<char> to = stacksOfCrates[instruction.to];
            crates.Reverse();
            foreach (var crate in crates)
            {
                to.Push(crate);
            }
        }

        private void ProcessInstruction(Instruction instruction)
        {
            for (int i=0; i<instruction.quantity;i++)
            {
                Stack<char> from = stacksOfCrates[instruction.from];
                Stack<char> to = stacksOfCrates[instruction.to];
                var crate = from.Pop();
                to.Push(crate);
            }
        }

        private void ProcessCrateLines(List<string> crateLines)
        {
            crateLines.Reverse();
            foreach (var crateline in crateLines)
            {
                var stacknr = 0;
                var rest = crateline;
                while (rest.Trim().Length > 0) {
                    var x = rest.Substring(0, 3);
                    stacknr++;
                    AddToStack(stacknr, x);
                    if (rest.Length > 4)
                    {
                        rest = rest.Substring(4);
                    }
                    else
                    {
                        rest = string.Empty;
                    }
                }
            }
        }

        private void AddToStack(int stacknr, string crate)
        {
            if (crate.Trim().Length == 0) return;
            if (!stacksOfCrates.ContainsKey(stacknr))
            {
                stacksOfCrates[stacknr] = new Stack<char>();
            }
            var stack = stacksOfCrates[stacknr];
            stack.Push(crate.ElementAt(1));
        }

        public string GetMessage()
        {
            ProcessInstructions(false);
            var result = "";
            for (int i=0;i<stacksOfCrates.Count;i++)
            {
                result += stacksOfCrates[i+1].Pop();
            }
            return result;
        }

        public object GetMessagePart2()
        {
            ProcessInstructions(true);
            var result = "";
            for (int i = 0; i < stacksOfCrates.Count; i++)
            {
                result += stacksOfCrates[i + 1].Pop();
            }
            return result;
        }
    }

    public static class Extensions
    {
        public static bool ContainsCrates(this string line)
        {
            return line.Trim().StartsWith("[");
        }

        public static bool ContainsInstruction(this string line)
        {
            return line.Trim().StartsWith("move");
        }
    }
}

