using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Days
{
    internal class Day06
    {
        public Day06()
        {
            Console.WriteLine("    Part 1 Solution: {0}\n", Day06Part1());
            Console.WriteLine("    Part 2 Solution: {0}\n", Day06Part2());
        }


        private static string Day06Part1()
        {
            StreamReader input = new("..\\..\\..\\Inputs\\Day06.txt");

            string timeStr = input.ReadLine()!;
            string distanceStr = input.ReadLine()!;

            List<int> times = new();
            List<int> distances = new();

            string[] timeSplit = timeStr.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] distanceSplit = distanceStr.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 1; i < timeSplit.Length; i++)
            {
                times.Add(Int32.Parse(timeSplit[i]));
                distances.Add(Int32.Parse(distanceSplit[i]));
            }

            int[] winCounts = new int[times.Count];
            int total = 1;

            for (int i = 0; i < times.Count; i++)
            {
                for (int j = 1; j < times[i] - 1; j++)
                {
                    if ((j * (times[i] - j) > distances[i]))
                        winCounts[i]++;
                }
                total *= winCounts[i];
            }

            input.Close();
            return total.ToString();
        }

        private static string Day06Part2()
        {
            StreamReader input = new("..\\..\\..\\Inputs\\Day06.txt");

            string timeStr = input.ReadLine()!;
            string distanceStr = input.ReadLine()!;

            string[] timeSplit = timeStr.Split(':');
            string[] distanceSplit = distanceStr.Split(':');

            long time = Int64.Parse(String.Concat(timeSplit[1].Where(c => !Char.IsWhiteSpace(c))));
            long distance = Int64.Parse(String.Concat(distanceSplit[1].Where(c => !Char.IsWhiteSpace(c))));

            int winCount = 0;

            for (int i = 1; i < time - 1; i++)
            {
                if ((i * (time - i) > distance))
                    winCount++;
            }

            input.Close();
            return winCount.ToString();
        }
    }
}
