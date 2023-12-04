using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Data;
using System.Runtime.InteropServices;

namespace AdventOfCode2023.Days
{
    internal class Day03
    {
        public Day03()
        {
            Console.WriteLine("    Part 1 Solution: {0}\n", Day03Part1());
            Console.WriteLine("    Part 2 Solution: {0}\n", Day03Part2());
        }

        

        private static string Day03Part1()
        {
            StreamReader input = new("..\\..\\..\\Inputs\\Day03.txt");


            int runningTotal = 0;

            string line = input.ReadLine()!;
            List<string> rows = new();

            while (line != null)
            {
                rows.Add(line);
                line = input.ReadLine()!;
            }

            static bool isValid(List<string> rows, int r, int c)
            {
                Vector2[] directions = {
                new (-1, 1), new (0, 1), new (1, 1),
                new (-1, 0),             new (1, 0),
                new (-1, -1), new (0, -1), new (1, -1) };

                bool v = false;

                for (int d = 0; d < directions.Length; d++)
                {
                    int row = r + (int)directions[d].X;
                    int column = c + (int)directions[d].Y;
                    if (row < 0 || row >= rows.Count)
                    {
                        continue;
                    }
                    if (column < 0 || column >= rows[0].Length)
                    {
                        continue;
                    }
                    if (rows[row][column] != '.'
                        && !Char.IsDigit(rows[row][column]))
                    {
                        v = true;
                    }
                }
                return v;
            }

            for (int r = 0; r < rows.Count; r++)
            {
                int currentNum = 0;
                bool validNum = false;

                for(int c = 0; c < rows.Count; c++)
                {
                    if (!Char.IsDigit(rows[r][c]))
                    {
                        if (validNum)
                        {
                            runningTotal += currentNum;
                        }
                        currentNum = 0;
                        validNum = false;
                    }
                    else
                    {
                        validNum = validNum || isValid(rows, r, c);

                        currentNum = currentNum * 10 + ((int)rows[r][c] - 48);

                        if (c == rows[r].Length - 1 && validNum)
                        {
                            runningTotal += currentNum;
                        }
                    }
                }
            }
            

            input.Close();
            return runningTotal.ToString();
        }

        private static string Day03Part2()
        {
            StreamReader input = new StreamReader("..\\..\\..\\Inputs\\Day03.txt");

            int runningTotal = 0;

            List<string> rows = new();
            string line = input.ReadLine()!;

            while (line != null)
            {
                rows.Add(line);
                line = input.ReadLine()!;
            }

            Dictionary<Vector2, int> map = new();
            Vector2[] directions = {
                new (-1, 1), new (0, 1), new (1, 1),
                new (-1, 0),             new (1, 0),
                new (-1, -1), new (0, -1), new (1, -1) };

            static bool isValid(List<string> rows, Vector2[] directions, int r, int c)
            {
                bool v = false;

                for (int d = 0; d < directions.Length; d++)
                {
                    int row = r + (int)directions[d].X;
                    int column = c + (int)directions[d].Y;
                    if (row < 0 || row >= rows.Count)
                    {
                        continue;
                    }
                    if (column < 0 || column >= rows[0].Length)
                    {
                        continue;
                    }
                    if (rows[row][column] != '.'
                        && !Char.IsDigit(rows[row][column]))
                    {
                        v = true;
                    }
                }
                return v;
            }

            for (int r = 0; r < rows.Count; r++)
            {
                int currentNum = 0;
                List<Vector2> indices = new();
                bool validNum = false;

                for (int c = 0; c < rows.Count; c++)
                {
                    if (!Char.IsDigit(rows[r][c]))
                    {
                        if (validNum)
                        {
                            for (int i = 0; i < indices.Count; i++)
                            {
                                map.Add(indices[i], currentNum);
                            }
                        }
                        currentNum = 0;
                        validNum = false;
                        indices = new();
                    }
                    else
                    {
                        validNum = validNum || isValid(rows, directions, r, c);

                        currentNum = currentNum * 10 + ((int)rows[r][c] - 48);
                        indices.Add(new Vector2(r, c));

                        if (c == rows[r].Length - 1 && validNum)
                        {
                            for (int i = 0; i < indices.Count; i++)
                            {
                                map.Add(indices[i], currentNum);
                            }
                        }
                    }
                }
            }

            for (int r = 0; r < rows.Count; r++ )
            {
                for (int c = 0; c < rows.Count; c++)
                {
                    if ((rows[r][c] == '*'))
                    {
                        Dictionary<int, bool> gearAdjSet = new(); 
                        for (int d = 0; d < directions.Length; d++)
                        {
                            int row = r + (int)directions[d].X;
                            int column = c + (int)directions[d].Y;

                            Vector2 coords = new(row, column);

                            if (map.ContainsKey(coords))
                            {
                                gearAdjSet[map[coords]] = true;
                            }
                        }
                        int gearRatio = 1;
                        if (gearAdjSet.Count >= 2)
                        {
                            foreach (var part in gearAdjSet)
                            {
                                gearRatio *= part.Key;
                            }
                            runningTotal += gearRatio;
                        }
                    }
                }
            }

            return runningTotal.ToString();
        }
    }
}
