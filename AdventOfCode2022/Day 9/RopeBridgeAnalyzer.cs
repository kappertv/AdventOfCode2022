using System;
namespace AdventOfCode2022.Day9;

public class RopeBridgeAnalyzer
{
    List<Instruction> instructions = new List<Instruction>();
    public RopeBridgeAnalyzer(string[] lines)
    {
        foreach(var line in lines)
        {
            var parts = line.Split(" ");
            instructions.Add(new Instruction(parts[0].First(), int.Parse(parts[1])));
        }
    }

    public (int minx, int maxx) GetRangeX()
    {
        var minx = 1;
        var maxx = 1;
        var currentx = 1;

        foreach (var inst in instructions)
        {
            if (inst.direction.Equals('R'))
                currentx += inst.steps;
            else if (inst.direction.Equals('L'))
                currentx -= inst.steps;

            minx = Math.Min(minx, currentx);
            maxx = Math.Max(maxx, currentx);
        }

        return (minx, maxx);
    }

    public (int miny, int maxy) GetRangeY()
    {
        var miny = 1;
        var maxy = 1;
        var currenty = 1;

        foreach (var inst in instructions)
        {
            if (inst.direction.Equals('U'))
                currenty += inst.steps;
            else if (inst.direction.Equals('D'))
                currenty -= inst.steps;

            miny = Math.Min(miny, currenty);
            maxy = Math.Max(maxy, currenty);
        }

        return (miny, maxy);
    }

    const int xmax = 330;
    const int ymax = 560;
    int[,] map = new int[xmax, ymax]; // X, Y == Hor, Ver, 0,0 == bottomleft
    Position head = new Position(138, 478);
    Position tail = new Position(138, 478);
    public List<int> GetOnceVisitedPositionsByTail()
    {
        AnalyzeAll();

        return ReadVisitedPositionFromMap();
    }

    private void AnalyzeAll()
    {
        InitializeMap();
        foreach (var instruction in instructions)
        {
            ProcessInstruction(instruction);
        }
    }

    public string[] GetOnceVisitedPositionsByTailVisualization()
    {
        AnalyzeAll();
        List<string> result = new List<string>();
        for (int y = 0; y < ymax; y++)
        {
            var line = new char[xmax];
            for (int x = 0; x < xmax; x++)
            {
                if (map[x, y] > 0)
                    line[x] = '#';
                else
                    line[x] = '.';
            }
            result.Add(new string(line));
        }
        result.Reverse();
        return result.ToArray();
    }

    private void InitializeMap()
    {
        for (int x = 0; x < xmax; x++)
        {
            for (int y = 0; y < ymax; y++)
            {
                map[x, y] = 0;
            }
        }
        map[0, 0]++;
    }

    private List<int> ReadVisitedPositionFromMap()
    {
        List<int> result = new List<int>();
        for (int x = 0; x < xmax; x++)
        {
            for (int y = 0; y < ymax; y++)
            {
                result.Add(map[x, y]);
            }
        }
        return result;
    }

    private void ProcessInstruction(Instruction instruction)
    {
        //Console.WriteLine($"instruction: {instruction.direction} {instruction.steps}");
        for (int i=0;i<instruction.steps;i++)
        {
            if (instruction.direction.Equals('U'))
                ProcessUpStep();
            else if (instruction.direction.Equals('D'))
                ProcessDownStep();
            else if (instruction.direction.Equals('L'))
                ProcesLeftStep();
            else if (instruction.direction.Equals('R'))
                ProcessRightStep();
            else
                throw new InvalidProgramException();
        }
    }

    private void ProcessUpStep()
    {
        head = new Position(head.X, head.Y + 1);
        CheckTail();
    }

    private void ProcessDownStep()
    {
        head = new Position(head.X, head.Y - 1);
        CheckTail();
    }

    private void ProcesLeftStep()
    {
        head = new Position(head.X - 1, head.Y);
        CheckTail();
    }

    private void ProcessRightStep()
    {
        head = new Position(head.X + 1, head.Y);
        CheckTail();
    }

    private int VerticalDif()
    {
        return Math.Abs(head.Y - tail.Y);
    }

    private int HorizontalDif()
    {
        return Math.Abs(head.X - tail.X);
    }

    //private bool DiagonalUpdateNeeded()
    //{
    //    return HorizontalDif() +
    //        VerticalDif() > 2;
    //}

    private void CheckTail()
    {
        if (VerticalDif() > 1)
        {
            tail = new Position(head.X,
                ((tail.Y + head.Y) / 2));
            UpdateMap();
        }
        else if (HorizontalDif() > 1) {
            tail = new Position(((tail.X + head.X) /2),
                head.Y);
            UpdateMap();
        }
        else
        {
            // Console.WriteLine($"head X,Y:{head.X},{head.Y}");
            // Console.WriteLine($"tail X,Y:{tail.X},{tail.Y}");
        }
    }

    private void UpdateMap()
    {
        // Console.WriteLine($"update head X,Y:{head.X},{head.Y}");
        // Console.WriteLine($"update tail X,Y:{tail.X},{tail.Y}");
        map[tail.X-1, tail.Y-1]++;
    }
}

public record Position(int X, int Y);
public record Instruction(char direction, int steps);

