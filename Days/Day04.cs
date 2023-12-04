using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Days
{
    internal class Day04
    {
        public Day04()
        {
            Console.WriteLine("    Part 1 Solution: {0}\n", Day04Part1());
            Console.WriteLine("    Part 2 Solution: {0}\n", Day04Part2());
        }

        private static string Day04Part1()
        {
            StreamReader input = new("..\\..\\..\\Inputs\\Day04.txt");
            int runningTotal = 0;
            
            string line = input.ReadLine()!;

            while (line != null)
            {
                string[] subs = line.Split(':', '|');
                string[] winningNums = subs[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] gameNums = subs[2].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int gameScore = 0;

                Dictionary<string, bool> map = new();

                for (int i = 0; i < winningNums.Length; i++)
                {
                    map.Add(winningNums[i], true);
                }

                for (int i = 0; i < gameNums.Length; i++)
                {
                    if (map.ContainsKey(gameNums[i]))
                    {
                        if (gameScore == 0)
                            gameScore++;
                        else
                            gameScore *= 2;
                    }
                }

                runningTotal += gameScore;

                line = input.ReadLine()!;
            }

            input.Close();
            return runningTotal.ToString();
        }

        private static string Day04Part2()
        {
            StreamReader input = new("..\\..\\..\\Inputs\\Day04.txt");
            int runningTotal = 0;

            string line = input.ReadLine()!;

            Dictionary<int, int> cardInstances = new();

            while (line != null)
            {
                string[] subs = line.Split(':', '|');
                int gameNum = Int32.Parse(subs[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
                string[] winningNums = subs[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] gameNums = subs[2].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int matches = 0;
                if (cardInstances.ContainsKey(gameNum))
                    cardInstances[gameNum] += 1;
                else
                    cardInstances.Add(gameNum, 1);

                runningTotal += cardInstances[gameNum];

                Dictionary<string, bool> map = new();

                for (int i = 0; i < winningNums.Length; i++)
                {
                    map.Add(winningNums[i], true);
                }

                for (int i = 0; i < gameNums.Length; i++)
                {
                    if (map.ContainsKey(gameNums[i]))
                    {
                        matches++;
                    }
                }

                for (int i = 0; i < cardInstances[gameNum]; i++)
                {
                    for (int j = 1; j <= matches; j++)
                    {
                        if (cardInstances.ContainsKey(gameNum + j))
                            cardInstances[gameNum + j] += 1;
                        else
                            cardInstances.Add(gameNum + j, 1);
                    }
                }

                line = input.ReadLine()!;
            }

            input.Close();
            return runningTotal.ToString();
        }
    }
}
