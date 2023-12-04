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
            StreamReader input = new("..\\..\\..\\Inputs\\Day04_Part1.txt");
            int runningTotal = 0;
            
            string line = input.ReadLine()!;

            while (line != null)
            {
                string[] subs = line.Split(':', ';');

                line = input.ReadLine()!;
            }

            input.Close();
            return runningTotal.ToString();
        }

        private static string Day04Part2()
        {
            StreamReader input = new StreamReader("..\\..\\..\\Inputs\\Day04_Part1.txt");
            int runningTotal = 0;

            string line = input.ReadLine()!;

            while (line != null)
            {
                string[] subs = line.Split(':', ';');
                
                line = input.ReadLine()!;
            }

            input.Close();
            return runningTotal.ToString();
        }
    }
}
