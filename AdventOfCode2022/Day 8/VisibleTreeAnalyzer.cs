using System;
using System.Runtime.ConstrainedExecution;

namespace AdventOfCode2022.Day8
{
    public class VisibleTreeAnalyzer
    {
        char[,] forest; // X, Y;
        int horcount; //X
        int vercount; //Y

        public VisibleTreeAnalyzer(string[] lines)
        {
            horcount = lines.First().Count();
            vercount = lines.Count();
            forest = new char[horcount,vercount];
            for (int i=0;i<vercount;i++)
            {
                for(int j=0;j<horcount;j++)
                {
                    var c = lines[i][j];
                    forest[i, j] = c;
                }
            }
        }

        public int GetNumberOfVisibleTree()
        {
            return GetOuterTrees() +
                GetInnerVisibleTrees();
        }

        private int GetInnerVisibleTrees()
        {
            var visible = 0;
            for (int i=1;i<vercount-1; i++)
            {
                for (int j=1;j<horcount-1;j++)
                {
                    if (IsVisibleTree(i, j)) visible++;
                }
            }
            return visible;
        }

        private bool IsVisibleTree(int ver, int hor)
        {
            var height = forest[ver, hor];
            
            var all = new List<bool>();
            all.Add(GetAllLeft(ver, hor));
            all.Add(GetAllRight(ver, hor));
            all.Add(GetAllDown(ver, hor));
            all.Add(GetAllUp(ver, hor));
            return all.Any(s => s.Equals(true));
        }

        private bool GetAllLeft(int ver, int hor)
        {
            var height = forest[ver, hor];
            var result = new List<char>();
            for (int i = hor - 1; i>=0;i--)
            {
                result.Add(forest[ver, i]);
            }
            return result.Max() < height;
        }

        private bool GetAllRight(int ver, int hor)
        {
            var height = forest[ver, hor];
            var result = new List<char>();
            for (int i = hor + 1; i < horcount; i++)
            {
                result.Add(forest[ver, i]);
            }
            return result.Max() < height;
        }

        private bool GetAllUp(int ver, int hor)
        {
            var height = forest[ver, hor];
            var result = new List<char>();
            for (int i = ver - 1; i >=0; i--)
            {
                result.Add(forest[i, hor]);
            }
            return result.Max() < height;
        }

        private bool GetAllDown(int ver, int hor)
        {
            var height = forest[ver, hor];
            var result = new List<char>();
            for (int i = ver + 1; i < vercount; i++)
            {
                result.Add(forest[i, hor]);
            }
            return result.Max() < height;
        }

        private int GetOuterTrees()
        {
            return (horcount * 2) + ((vercount - 2) * 2);
        }

        public int GetTreeWithHighestScenicScore()
        {
            var scenicscores = new List<int>();
            for (int i = 1; i < vercount - 1; i++)
            {
                for (int j = 1; j < horcount - 1; j++)
                {
                    var scenicscore = GetScenicScore(i, j);
                    scenicscores.Add(scenicscore);
                }
            }
            return scenicscores.Max();
        }

        private int GetScenicScore(int ver, int hor)
        {
            var height = forest[ver, hor];

            var west = GetScenicScoreWest(ver, hor);
            var east = GetScenicScoreEast(ver, hor);
            var north = GetScenicScoreNorth(ver, hor);
            var south = GetScenicScoreSouth(ver, hor);

            return west * east * north * south;
        }

        private int GetScenicScoreWest(int ver, int hor)
        {
            var height = forest[ver, hor];
            var result = 0;
            for (int i = hor - 1; i >= 0; i--)
            {
                result++;
                if (forest[ver, i] >= height) return result;
            }
            return result;
        }

        private int GetScenicScoreEast(int ver, int hor)
        {
            var height = forest[ver, hor];
            var result = 0;
            for (int i = hor + 1; i < horcount; i++)
            {
                result++;
                if (forest[ver, i] >= height) return result;
            }
            return result;
        }

        private int GetScenicScoreNorth(int ver, int hor)
        {
            var height = forest[ver, hor];
            var result = 0;
            for (int i = ver - 1; i >= 0; i--)
            {
                result++;
                if (forest[i, hor] >= height) return result;
            }
            return result;
        }

        private int GetScenicScoreSouth(int ver, int hor)
        {
            var height = forest[ver, hor];
            var result = 0;
            for (int i = ver + 1; i < vercount; i++)
            {
                result++;
                if (forest[i, hor] >= height) return result;
            }
            return result;
        }
    }
}

