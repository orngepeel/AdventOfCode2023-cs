using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Days
{
    internal class Day01
    {
        public Day01() 
        {
            Console.WriteLine("Day 1!\n");
            Console.WriteLine(Part1() + "\n");
            Console.WriteLine(Part2() + "\n");
        }

        private String Part1()
        {
            int runningTotal = 0;
            StreamReader input = new StreamReader("..\\..\\..\\Inputs\\Day01_Part1.txt");

            String line = input.ReadLine();

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

                String cvString = new string(cv);
                int calibrationValue = int.Parse(cvString);
                runningTotal += calibrationValue;

                line = input.ReadLine();
            }
            input.Close();
            return runningTotal.ToString();
        }

        private String Part2() 
        {
            return "";
        }
    }
}
