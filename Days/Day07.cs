using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Days
{
    internal class Day07
    {
        public Day07()
        {
            Console.WriteLine("    Part 1 Solution: {0}\n", Day07Part1());
            Console.WriteLine("    Part 2 Solution: {0}\n", Day07Part2());
        }


        private static string Day07Part1()
        {
            StreamReader input = new("..\\..\\..\\Inputs\\Day07.txt");

            Dictionary<char, int> cardVals = new()
            {
                {'A', 13},
                {'K', 12},
                {'Q', 11},
                {'J', 10},
                {'T', 9},
                {'9', 8},
                {'8', 7},
                {'7', 6},
                {'6', 5},
                {'5', 4},
                {'4', 3},
                {'3', 2},
                {'2', 1},
            };

            // (hand, hand type, bid, score)
            List<(string, string, int, int)> hands = new();

            string line = input.ReadLine()!;

            while (line != null)
            {
                string[] parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string hand = parts[0];
                int bid = int.Parse(parts[1]);

                // Find hand type
                string handType = "";
                int[] cardCounts = new int[13];

                for (int i = 0; i < hand.Length; i++)
                {
                    cardCounts[cardVals[hand[i]] - 1]++;
                }

                // score hands for sorting
                int handScore = 0;

                Array.Sort(cardCounts, (a, b) => b.CompareTo(a));

                switch (cardCounts[0])
                {
                    case 5:
                        handType = "A - Five of a Kind";
                        handScore = 6;
                        break;
                    case 4:
                        handType = "B - Four of a Kind";
                        handScore = 5;
                        break;
                    case 3:
                        if (cardCounts[1] == 2)
                        {
                            handType = "C - Full House";
                            handScore = 4;
                        }
                        else
                        {
                            handType = "D - Three of a Kind";
                            handScore = 3;
                        }
                        break;
                    case 2:
                        if (cardCounts[1] == 2)
                        {
                            handType = "E - Two Pair";
                            handScore = 2;
                        }
                        else
                        {
                            handType = "F - One Pair";
                            handScore = 1;
                        }
                        break;
                    default:
                        handType = "G - High Card";
                        break;
                }

                hands.Add((hand, handType, bid, handScore));

                line = input.ReadLine()!;
            }

            hands = hands.OrderBy(x => x.Item4)
                .ThenBy(a => cardVals[a.Item1[0]])
                .ThenBy(b => cardVals[b.Item1[1]])
                .ThenBy(c => cardVals[c.Item1[2]])
                .ThenBy(d => cardVals[d.Item1[3]])
                .ThenBy(e => cardVals[e.Item1[4]])
                .ToList();

            int totalScore = 0;

            for (int i = 0; i < hands.Count; i++)
            {
                totalScore += hands[i].Item3 * (i + 1);
            }

            return totalScore.ToString();
        }

        private static string Day07Part2()
        {
            StreamReader input = new("..\\..\\..\\Inputs\\Day07.txt");

            Dictionary<char, int> cardVals = new()
            {
                {'A', 13},
                {'K', 12},
                {'Q', 11},
                {'T', 10},
                {'9', 9},
                {'8', 8},
                {'7', 7},
                {'6', 6},
                {'5', 5},
                {'4', 4},
                {'3', 3},
                {'2', 2},
                {'J', 1}
            };

            // (hand, hand type, bid, score)
            List<(string, string, int, int)> hands = new();

            string line = input.ReadLine()!;

            while (line != null)
            {
                string[] parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string hand = parts[0];
                int bid = int.Parse(parts[1]);

                // Find hand type
                string handType = "";
                int[] cardCounts = new int[13];
                int jokerCount = 0;

                for (int i = 0; i < hand.Length; i++)
                { 
                    cardCounts[cardVals[hand[i]] - 1]++;
                    if (hand[i] == 'J')
                        jokerCount++;
                }

                // score hands for sorting
                int handScore = 0;

                Array.Sort(cardCounts, (a, b) => b.CompareTo(a));

                switch (cardCounts[0])
                {
                    case 5:
                        handType = "A - Five of a Kind";
                        handScore = 6;
                        break;
                    case 4:
                        handType = "B - Four of a Kind";
                        handScore = 5;
                        if (jokerCount >= 1)
                        {
                            handType = "A - Five of a Kind";
                            handScore = 6;
                        }
                        break;
                    case 3:
                        if (cardCounts[1] == 2)
                        {
                            handType = "C - Full House";
                            handScore = 4;
                            if (jokerCount >= 2)
                            {
                                handType = "A - Five of a Kind";
                                handScore = 6;
                            }
                        }
                        else
                        {
                            handType = "D - Three of a Kind";
                            handScore = 3;
                            if (jokerCount >= 1)
                            {
                                handType = "B - Four of a Kind";
                                handScore = 5;
                            }
                        }
                        break;
                    case 2:
                        if (cardCounts[1] == 2)
                        {
                            handType = "E - Two Pair";
                            handScore = 2;
                            if (jokerCount == 2)
                            {
                                handType = "B - Four of a Kind";
                                handScore = 5;
                            }
                            if (jokerCount == 1)
                            {
                                handType = "C - Full House";
                                handScore = 4;
                            }
                        }
                        else
                        {
                            handType = "F - One Pair";
                            handScore = 1;
                            if (jokerCount >= 1)
                            {
                                handType = "D - Three of a Kind";
                                handScore = 3;
                            }
                        }
                        break;
                    default:
                        handType = "G - High Card";
                        if (jokerCount == 1)
                        {
                            handType = "F - One Pair";
                            handScore = 1;
                        }
                        
                        break;
                }

                hands.Add((hand, handType, bid, handScore));

                line = input.ReadLine()!;
            }

            hands = hands.OrderBy(x => x.Item4)
                .ThenBy(a => cardVals[a.Item1[0]])
                .ThenBy(b => cardVals[b.Item1[1]])
                .ThenBy(c => cardVals[c.Item1[2]])
                .ThenBy(d => cardVals[d.Item1[3]])
                .ThenBy(e => cardVals[e.Item1[4]])
                .ToList();

            int totalScore = 0;

            for (int i = 0; i < hands.Count; i++)
            {
                Console.WriteLine(hands[i]);
                totalScore += hands[i].Item3 * (i + 1);
            }

            return totalScore.ToString();
        }
    }
}
