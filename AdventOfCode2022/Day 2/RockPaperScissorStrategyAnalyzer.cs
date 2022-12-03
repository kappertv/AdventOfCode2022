using System;

namespace AdventOfCode2022.Day2
{
	public class RockPaperScissorStrategyAnalyzer
	{
		public RockPaperScissorStrategyAnalyzer(string[] lines)
		{
            ReadLines(lines);
		}

        public List<Round> rounds = new List<Round>();
        private void ReadLines(string[] lines)
        {
            foreach (var line in lines)
            {
                var opponentEnum = GetPaperRockScissors(line.Take(1).First());
                var selfEnum = GetPaperRockScissors(line.TakeLast(1).First());
                rounds.Add(new Round(opponentEnum, selfEnum));
            }
        }

        private RockPaperScissor GetPaperRockScissors(char enumerable) => enumerable switch
        {
            'A' => RockPaperScissor.Rock,
            'B' => RockPaperScissor.Paper,
            'C' => RockPaperScissor.Scissor,
            'X' => RockPaperScissor.Rock,
            'Y' => RockPaperScissor.Paper,
            'Z' => RockPaperScissor.Scissor,
            _ => throw new ArgumentException($"Not expected value of character:{enumerable}", nameof(enumerable)),
        };

        public long GetScore()
        {
            return rounds.Sum(s => s.GetScore());
        }

        public object GetScorePart2()
        {
            return rounds.Sum(s => s.GetScorePart2());
        }
    }
}

