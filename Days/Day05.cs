using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Days
{
    internal class Day05
    {
        public Day05()
        {
            Console.WriteLine("    Part 1 Solution: {0}\n", Day05Part1());
            Console.WriteLine("    Part 2 Solution: {0}\n", Day05Part2());
        }

        private static string Day05Part1()
        {
            StreamReader input = new("..\\..\\..\\Inputs\\Day05.txt");

            string line = input.ReadLine()!;

            // First line has seeds
            string currentStep = "seeds";
            string[] subs = line.Split(' ');

            long[] seeds = new long[subs.Length - 1];

            for (int i = 1; i < subs.Length; i++)
            {
                seeds[i - 1] = long.Parse(subs[i]);
            }

            string[] steps = new string[seeds.Length];

            for (int i = 0; i < steps.Length; i++)
            {
                steps[i] = currentStep;
            }

            line = input.ReadLine()!;

            while (line != null)
            {
                if (line.Length == 0)
                {
                    line = input.ReadLine()!;
                    continue;
                }

                switch (line)
                {
                    case "seed-to-soil map:":
                        currentStep = "soil";
                        line = input.ReadLine()!;
                        continue;
                    case "soil-to-fertilizer map:":
                        currentStep = "fertilizer";
                        line = input.ReadLine()!;
                        continue;
                    case "fertilizer-to-water map:":
                        currentStep = "water";
                        line = input.ReadLine()!;
                        continue;
                    case "water-to-light map:":
                        currentStep = "light";
                        line = input.ReadLine()!;
                        continue;
                    case "light-to-temperature map:":
                        currentStep = "temperature";
                        line = input.ReadLine()!;
                        continue;
                    case "temperature-to-humidity map:":
                        currentStep = "humidity";
                        line = input.ReadLine()!;
                        continue;
                    case "humidity-to-location map:":
                        currentStep = "location";
                        line = input.ReadLine()!;
                        continue;
                    default:
                        break;
                }

                long destinationNum = long.Parse(line.Split(' ')[0]);
                long sourceNum = long.Parse(line.Split(' ')[1]);
                long rangeNum = long.Parse(line.Split(' ')[2]);

                for (int i = 0; i < seeds.Length; i++)
                {
                    // if number is not mapped, it stays the same
                    if (seeds[i] >= sourceNum + rangeNum || seeds[i] < sourceNum || steps[i] == currentStep)
                        continue;

                    // seed - range + source
                    if (sourceNum <= destinationNum)
                    {
                        seeds[i] = (destinationNum - sourceNum) + seeds[i];
                        steps[i] = currentStep;
                    }
                    else
                    {
                        seeds[i] = (seeds[i] - sourceNum) + destinationNum;
                        steps[i] = currentStep;
                    }
                }

                line = input.ReadLine()!;
            }

            input.Close();
            return seeds.Min().ToString();
        }

        private static string Day05Part2()
        {
            // This is really not optimized, it's essentially brute force with some parallelization
            // TODO: implement a better solution
            StreamReader input = new("..\\..\\..\\Inputs\\Day05.txt");

            string line = input.ReadLine()!;

            // First line has seeds
            string currentStep = "seeds";
            string[] subs = line.Split(' ');

            long[] seedNums = new long[subs.Length - 1];

            for (int i = 1; i < subs.Length; i++)
            {
                seedNums[i - 1] = long.Parse(subs[i]);
            }

            List<long> seeds = new();

            for (int i = 0; i < seedNums.Length - 1; i += 2)
            {
                long seed = seedNums[i];
                for (int j = 0; j < seedNums[i + 1]; j++)
                {
                    seeds.Add(seed);
                    seed++;
                }

            }

            string[] steps = new string[seeds.Count];

            Parallel.For(0, steps.Length, new ParallelOptions { MaxDegreeOfParallelism = -1 }, i =>
            {
                steps[i] = currentStep;
            });

            line = input.ReadLine()!;

            while (line != null)
            {
                if (line.Length == 0)
                {
                    line = input.ReadLine()!;
                    continue;
                }

                switch (line)
                {
                    case "seed-to-soil map:":
                        currentStep = "soil";
                        line = input.ReadLine()!;
                        continue;
                    case "soil-to-fertilizer map:":
                        currentStep = "fertilizer";
                        line = input.ReadLine()!;
                        continue;
                    case "fertilizer-to-water map:":
                        currentStep = "water";
                        line = input.ReadLine()!;
                        continue;
                    case "water-to-light map:":
                        currentStep = "light";
                        line = input.ReadLine()!;
                        continue;
                    case "light-to-temperature map:":
                        currentStep = "temperature";
                        line = input.ReadLine()!;
                        continue;
                    case "temperature-to-humidity map:":
                        currentStep = "humidity";
                        line = input.ReadLine()!;
                        continue;
                    case "humidity-to-location map:":
                        currentStep = "location";
                        line = input.ReadLine()!;
                        continue;
                    default:
                        break;
                }

                long destinationNum = long.Parse(line.Split(' ')[0]);
                long sourceNum = long.Parse(line.Split(' ')[1]);
                long rangeNum = long.Parse(line.Split(' ')[2]);

                Parallel.For(0, seeds.Count, new ParallelOptions { MaxDegreeOfParallelism = 4} ,i =>
                {
                    // if number is not mapped, it stays the same
                    if (seeds[i] >= sourceNum + rangeNum || seeds[i] < sourceNum || steps[i] == currentStep)
                        return;

                    // seed - range + source
                    if (sourceNum <= destinationNum)
                    {
                        seeds[i] = (destinationNum - sourceNum) + seeds[i];
                        steps[i] = currentStep;
                    }
                    else
                    {
                        seeds[i] = (seeds[i] - sourceNum) + destinationNum;
                        steps[i] = currentStep;
                    }
                });

                line = input.ReadLine()!;
            }

            input.Close();
            return seeds.Min().ToString();
        }
    }
}
