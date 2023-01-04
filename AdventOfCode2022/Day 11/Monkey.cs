using System;
namespace AdventOfCode2022.Day11
{
    public class Monkey
    {
        public Monkey(int nr, int[] items, string operation, string test, int monkeytesttrue, int monkeytestfalse)
        {
            Nr = nr;
            Items = items;
            Operation = operation;
            Test = test;
            Monkeytesttrue = monkeytesttrue;
            Monkeytestfalse = monkeytestfalse;
        }

        public int Nr { get; }
        public int[] Items { get; }
        public string Operation { get; }
        public string Test { get; }
        public int Monkeytesttrue { get; }
        public int Monkeytestfalse { get; }
    }
}

