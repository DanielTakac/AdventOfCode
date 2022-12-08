using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day8 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput(path: "demo.txt");

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

                    // 30373
                    // 25512
                    // 65332
                    // 33549
                    // 35390

                    if (j < 1) continue;

                    bool VisibleFromLeft(int i, int j) {

                        while (j - 1 >= 0 && input[i][j - 1] < input[i][j]) {

                            if (j - 2 < 0) return true;

                            j--;

                        }

                        return false;

                    }

                    bool VisibleFromRight(int i, int j) {

                        while (j + 1 < input[i].Length && input[i][j + 1] < input[i][j]) {

                            if (j >= input[i].Length) return true;

                            j++;

                        }

                        return false;

                    }

                    if (VisibleFromLeft(i, j) || VisibleFromRight(i, j)) {

                        Console.Write($"Adding {input[i][j]} at index [{i}, {j}] - ");
                        Console.WriteLine($"Left: {VisibleFromLeft(i, j)} - Right: {VisibleFromRight(i, j)}");

                        part1++;

                    }

                }

            }

            AdventOfCode.PrintWithColor($"Part 1: {part1}");

            Console.ReadKey();

        }

    }

}
