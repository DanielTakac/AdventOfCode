using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day8 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput(path: "input.txt");

            int part1 = 0;

            for (int i = 0; i < input.Length; i++) {

                if (i == 0 || i == input.Length - 1) {

                    part1 += input[i].Length;
                    continue;

                }

                for (int j = 0; j < input[i].Length; j++) {

                    if (j == 0 || j == input[i].Length - 1) {

                        part1++;
                        continue;

                    }

                    if (j < 1) continue;

                    bool VisibleFromLeft(int i, int j) {

                        for (int x = j - 1; x >= 0; x--) {

                            if (input[i][x] >= input[i][j]) return false;

                        }

                        return true;

                    }

                    bool VisibleFromRight(int i, int j) {

                        for (int x = j + 1; x < input[i].Length; x++) {

                            if (input[i][x] >= input[i][j]) return false;

                        }

                        return true;

                    }

                    bool VisibleFromBottom(int i, int j) {

                        for (int x = i + 1; x < input.Length; x++) {

                            if (input[x][j] >= input[i][j]) return false;

                        }

                        return true;

                    }

                    bool VisibleFromTop(int i, int j) {

                        for (int x = i - 1; x >= 0; x--) {

                            if (input[x][j] >= input[i][j]) return false;

                        }

                        return true;

                    }

                    if (VisibleFromLeft(i, j) || VisibleFromRight(i, j) || VisibleFromBottom(i, j) || VisibleFromTop(i, j)) {

                        Console.Write($"Adding {input[i][j]} at index [{i}, {j}] - ");
                        Console.WriteLine($"Left: {VisibleFromLeft(i, j)} - Right: {VisibleFromRight(i, j)} - Bottom: {VisibleFromBottom(i, j)} - Top: {VisibleFromTop(i, j)}");

                        part1++;

                    }

                }

            }

            AdventOfCode.PrintWithColor($"Part 1: {part1}");

            Console.ReadKey();

        }

    }

}
