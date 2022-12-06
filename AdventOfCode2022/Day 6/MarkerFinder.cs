using System;
namespace AdventOfCode2022.Day6
{
    public static class MarkerFinder
    {
        public static int FindMarker(string line)
        {
            var marker = 4;
            var markerfound = false;
            while (!markerfound)
            {
                marker++;
                var m = line.Substring(marker - 4, 4);
                if (m.Distinct().Count().Equals(4))
                {
                    markerfound = true;
                }
            }
            return marker;
        }

        public static int FindStartOfMessageMarker(string line)
        {
            var marker = 14;
            var markerfound = false;
            while (!markerfound)
            {
                marker++;
                var m = line.Substring(marker - 14, 14);
                if (m.Distinct().Count().Equals(14))
                {
                    markerfound = true;
                }
            }
            return marker;
        }
    }
}

