using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Days
{
    internal class Day02
    {
        public Day02()
        {
            Console.WriteLine("    Part 1 Solution: {0}\n", Day02Part1());
            Console.WriteLine("    Part 2 Solution: {0}\n", Day02Part2());
        }

        private static string Day02Part1()
        {
            StreamReader input = new("..\\..\\..\\Inputs\\Day02.txt");
            int runningTotal = 0;
            int maxRed = 12;
            int maxGreen = 13;
            int maxBlue = 14;
            string line = input.ReadLine()!;

            while (line != null)
            {
                string[] subs = line.Split(':', ';');
                int gameID = int.Parse(subs[0].Split(' ')[1]);
                
                bool validGame = true;
                for ( int i = 1;  i < subs.Length; i++ )
                {
                    string[] rounds = subs[i].Split(',');
                    for ( int j = 0; j < rounds.Length; j++ )
                    {
                        int n = int.Parse(rounds[j].Split(' ')[1]);
                        string color = rounds[j].Split(' ')[2];
                        if (color == "red" && n > maxRed)
                        {
                            validGame = false;
                        }
                        if (color == "green" && n > maxGreen)
                        {
                            validGame = false;
                        }
                        if (color == "blue" && n > maxBlue)
                        {
                            validGame = false;
                        }
                    }
                }
                    if (validGame)
                    {
                        runningTotal += gameID;
                    }

                line = input.ReadLine()!;
            }

            input.Close();  
            return runningTotal.ToString();
        }

        private static string Day02Part2()
        {
            StreamReader input = new StreamReader("..\\..\\..\\Inputs\\Day02.txt");
            int runningTotal = 0;
            
            string line = input.ReadLine()!;

            while (line != null)
            {
                string[] subs = line.Split(':', ';');
                int minRed = 0;
                int minGreen = 0;
                int minBlue = 0;
                for (int i = 1; i < subs.Length; i++)
                {
                    string[] rounds = subs[i].Split(',');
                    for (int j = 0; j < rounds.Length; j++)
                    {
                        int n = int.Parse(rounds[j].Split(' ')[1]);
                        string color = rounds[j].Split(' ')[2];
                        if (color == "red" && n > minRed)
                        {
                            minRed = n;
                        }
                        if (color == "green" && n > minGreen)
                        {
                            minGreen = n;
                        }
                        if (color == "blue" && n > minBlue)
                        {
                            minBlue = n;
                        }
                    }
                }

                int gamePower = minRed * minGreen * minBlue;
                runningTotal += gamePower;


                line = input.ReadLine()!;
            }

            input.Close();
            return runningTotal.ToString();
        }
    }
}
