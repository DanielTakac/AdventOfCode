using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day9 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput(path: "input.txt");

            int[] head = new int[] { 0, 0 };
            int[] tail = new int[] { 0, 0 };

            List<int[]> visitedPositions = new List<int[]>();
            
            visitedPositions.Add(new int[] { 0, 0 });

            void PrintCurrentPositions() {

                for (int i = 4; i >= 0; i--) {

                    for (int j = 0; j < 6; j++) {

                        if (head[1] == i && head[0] == j) {

                            Console.Write("H");

                        } else if (tail[1] == i && tail[0] == j) {

                            Console.Write("T");

                        } else if (i == 0 && j == 0) {

                            Console.Write("s");

                        } else {

                            Console.Write(".");

                        }

                    }

                    Console.WriteLine();

                }

                Console.WriteLine();

            }

            foreach (string line in input) {

                char direction = line[0];
                int distance = int.Parse(line.Split(' ')[1]);

                Console.WriteLine($"== {direction} {distance} ==\n");

                switch (direction) {

                    case 'L':

                        for (int i = 0; i < distance; i++) {

                            if (head[0] < tail[0]) {

                                tail[0] = head[0];
                                tail[1] = head[1];

                                visitedPositions.Add(new int[] { tail[0], tail[1] });

                            }

                            head[0]--;

                            // PrintCurrentPositions();

                        }

                        break;

                    case 'R':

                        for (int i = 0; i < distance; i++) {

                            if (head[0] > tail[0]) {

                                tail[0] = head[0];
                                tail[1] = head[1];

                                visitedPositions.Add(new int[] { tail[0], tail[1] });

                            }

                            head[0]++;

                            // PrintCurrentPositions();

                        }

                        break;

                    case 'U':

                        for (int i = 0; i < distance; i++) {

                            if (head[1] > tail[1]) {

                                tail[0] = head[0];
                                tail[1] = head[1];

                                visitedPositions.Add(new int[] { tail[0], tail[1] });

                            }

                            head[1]++;

                            // PrintCurrentPositions();

                        }

                        break;

                    case 'D':

                        for (int i = 0; i < distance; i++) {

                            if (head[1] < tail[1]) {

                                tail[0] = head[0];
                                tail[1] = head[1];

                                visitedPositions.Add(new int[] { tail[0], tail[1] });

                            }

                            head[1]--;

                            // PrintCurrentPositions();

                        }

                        break;

                    default:

                        AdventOfCode.PrintWithColor("Error!", ConsoleColor.Red);

                        break;

                }

                AdventOfCode.PrintWithColor($"{head[0]} - {head[1]}", ConsoleColor.Cyan);
                AdventOfCode.PrintWithColor($"{tail[0]} - {tail[1]}\n", ConsoleColor.Cyan);

            }

            for (int i = 100; i >= -150 ; i--) { // 4

                for (int j = -120; j < 80; j++) { // 6

                    bool isVisited = false;

                    foreach (int[] position in visitedPositions) {

                        if (position[1] == i && position[0] == j) {

                            isVisited = true;

                        }

                    }

                    if (isVisited) {

                        Console.Write("#");

                    } else {

                        Console.Write(".");

                    }

                }

                Console.WriteLine();

            }

            Console.WriteLine();

            int part1 = visitedPositions.Distinct().Count() - 1;

            AdventOfCode.PrintWithColor($"{head[0]} - {head[1]}", ConsoleColor.Cyan);
            AdventOfCode.PrintWithColor($"{tail[0]} - {tail[1]}\n", ConsoleColor.Cyan);

            AdventOfCode.PrintWithColor($"Part 1: {part1}");

            Console.ReadKey();

        }

    }

}
