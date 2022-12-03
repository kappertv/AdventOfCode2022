using System;
namespace AdventOfCode2022.Day2
{
	public record Round(RockPaperScissor Opponent, RockPaperScissor Self)
	{
        // Rock defeats Scissors, Scissors defeats Paper, and Paper defeats Rock. 
        public long GetScore()
        {
            long result;
            if (Opponent.Equals(Self))
            {
                result = 3 + (long)Self;
            }
            else if ((Opponent.Equals(RockPaperScissor.Rock) && Self.Equals(RockPaperScissor.Scissor)) ||
                     (Opponent.Equals(RockPaperScissor.Scissor) && Self.Equals(RockPaperScissor.Paper)) ||
                     (Opponent.Equals(RockPaperScissor.Paper) && Self.Equals(RockPaperScissor.Rock)))
            {
                result = 0 + (long)Self;
            }
            else
            {
                result = 6 + (long)Self;
            }
            //Console.WriteLine(result);
            return result;
        }

        // x = lose, y= = draw, z = win.
        public long GetScorePart2()
        {
            switch (Self)
            {
                case RockPaperScissor.Rock:
                    return GetLosingScoreOn(Opponent);
                case RockPaperScissor.Paper:
                    return GetDrawScoreOn(Opponent);
                case RockPaperScissor.Scissor:
                    return getWinningScoreOn(Opponent);
                default:
                    throw new InvalidOperationException();
            }
        }

        private long getWinningScoreOn(RockPaperScissor opponent)
        {
            if (opponent.Equals(RockPaperScissor.Rock))
            {
                return 6 + 2;
            }
            else if (opponent.Equals(RockPaperScissor.Paper))
            {
                return 6 + 3;
            }
            else
            {
                return 6 + 1;
            }
        }

        private long GetDrawScoreOn(RockPaperScissor opponent)
        {
            if (opponent.Equals(RockPaperScissor.Rock))
            {
                return 3 + 1;
            }
            else if (opponent.Equals(RockPaperScissor.Paper))
            {
                return 3 + 2;
            }
            else
            {
                return 3 + 3;
            }
        }

        private long GetLosingScoreOn(RockPaperScissor opponent)
        {
            if (opponent.Equals(RockPaperScissor.Rock))
            {
                return 0 + 3;
            }
            else if (opponent.Equals(RockPaperScissor.Paper))
            {
                return 0 + 1;
            }
            else
            {
                return 0 + 2;
            }
        }
    }
}

