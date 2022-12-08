using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day8 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput();

            int part1 = 0;
            int part2 = 0;

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

                        part1++;

                    }

                    int LeftScenicScore(int i, int j) {

                        int treesVisible = 0;

                        for (int x = j - 1; x >= 0; x--) {

                            treesVisible++;

                            if (input[i][x] >= input[i][j]) return treesVisible;

                        }

                        return treesVisible;

                    }

                    int RightScenicScore(int i, int j) {

                        int treesVisible = 0;

                        for (int x = j + 1; x < input[i].Length; x++) {

                            treesVisible++;

                            if (input[i][x] >= input[i][j]) return treesVisible;

                        }

                        return treesVisible;

                    }

                    int BottomScenicScore(int i, int j) {

                        int treesVisible = 0;

                        for (int x = i + 1; x < input.Length; x++) {

                            treesVisible++;

                            if (input[x][j] >= input[i][j]) return treesVisible;

                        }

                        return treesVisible;

                    }

                    int TopScenicScore(int i, int j) {

                        int treesVisible = 0;

                        for (int x = i - 1; x >= 0; x--) {

                            treesVisible++;

                            if (input[x][j] >= input[i][j]) return treesVisible;

                        }

                        return treesVisible;

                    }

                    int scenicScore = LeftScenicScore(i, j) * RightScenicScore(i, j) * BottomScenicScore(i, j) * TopScenicScore(i, j);

                    if (scenicScore > part2) part2 = scenicScore;

                }

            }

            AdventOfCode.PrintWithColor($"Part 1: {part1}");
            AdventOfCode.PrintWithColor($"Part 2: {part2}");

            Console.ReadKey();

        }

    }

}
