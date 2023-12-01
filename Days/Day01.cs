using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Days
{
    internal class Day01
    {
        public Day01() 
        {
            Console.WriteLine("    Part 1 Solution: {0}\n", Part1());
            Console.WriteLine("    Part 2 Solution: {0}\n", Part2());
        }

        private static string Part1()
        {
            int runningTotal = 0;
            StreamReader input = new StreamReader("..\\..\\..\\Inputs\\Day01_Part1.txt");

            string line = input.ReadLine()!;

            while (line != null)
            {
                bool first = false;
                bool last = false;

                int l = 0;
                int r = line.Length - 1;

                char[] cv = { '0', '0'};

                while (!first)
                {
                    char c = line[l];
                    if(Char.IsDigit(c))
                    {
                        first = true;
                        cv[0] = c;
                    }
                    else
                    {
                        l++;
                    }
                }

                while (!last)
                {
                    char c = line[r];
                    if (Char.IsDigit(c))
                    {
                        last = true;
                        cv[1] = c;
                    }
                    else
                    {
                        r--;
                    }
                }

                string cvString = new string(cv);
                int calibrationValue = int.Parse(cvString);
                runningTotal += calibrationValue;

                line = input.ReadLine()!;
            }
            input.Close();
            return runningTotal.ToString();
        }

        private static string Part2() 
        {
            var spelledNums = new Dictionary<string, Char>()
            {
                {"one", '1'},
                {"two", '2'},
                {"three", '3'},
                {"four", '4'},
                {"five", '5'},
                {"six", '6'},
                {"seven", '7'},
                {"eight", '8'},
                {"nine", '9'}
            };

            int runningTotal = 0;
            StreamReader input = new StreamReader("..\\..\\..\\Inputs\\Day01_Part1.txt");

            string line = input.ReadLine()!;

            while (line != null)
            {
                List<char> digits = new();

                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];
                    if (Char.IsDigit(c))
                    {
                        digits.Add(c);
                    }
                    else
                    {
                        if (i + 4 < line.Length && spelledNums.ContainsKey(line.Substring(i, 5)))
                        {
                            digits.Add(spelledNums[line.Substring(i, 5)]);
                        }
                        else if (i + 3 < line.Length && spelledNums.ContainsKey(line.Substring(i, 4)))
                        {
                            digits.Add(spelledNums[line.Substring(i, 4)]);
                        }
                        else if (i + 2 < line.Length && spelledNums.ContainsKey(line.Substring(i, 3)))
                        {
                            digits.Add(spelledNums[line.Substring(i, 3)]);
                        }
                    }
                }

                char[] cv = { digits[0], digits[digits.Count - 1]};

                string cvString = new(cv);
                int calibrationValue = int.Parse(cvString);
                runningTotal += calibrationValue;

                line = input.ReadLine()!;
            }

            input.Close();
            return runningTotal.ToString();
        }
    }
}
