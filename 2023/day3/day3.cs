using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day3 : Day {

        protected override string Part1() {

            string[] lines = AdventOfCode.GetInput();

            // PrintSchematic(lines);

            List<int> partNumbers = GetPartNumbers(lines);

            int sumOfPartNumbers = partNumbers.Sum();

            return sumOfPartNumbers.ToString();

        }

        private void PrintSchematic(string[] map) {

            for (int rowIndex = 0; rowIndex < map.Length; rowIndex++) {

                string row = map[rowIndex];

                for (int columnIndex = 0; columnIndex < row.Length; columnIndex++) {

                    if (row[columnIndex] == '.') {

                        AdventOfCode.PrintWithColor(row[columnIndex], ConsoleColor.Gray, false);

                    } else if (Char.IsNumber(row[columnIndex])) {

                        AdventOfCode.PrintWithColor(row[columnIndex], ConsoleColor.Cyan, false);

                    } else {

                        AdventOfCode.PrintWithColor(row[columnIndex], ConsoleColor.Magenta, false);

                    }

                }

                Console.WriteLine();

            }

        }

        private List<int> GetPartNumbers(string[] map) {

            List<int> partNumbers = new List<int>();

            for (int rowIndex = 0; rowIndex < map.Length; rowIndex++) {

                string row = map[rowIndex];

                for (int columnIndex = 0; columnIndex < row.Length; columnIndex++) {

                    if (row[columnIndex] == '.' || Char.IsNumber(row[columnIndex])) {

                        continue;

                    }

                    // Find numbers around part
                    for (int adjacentRowIndex = rowIndex - 1; adjacentRowIndex <= rowIndex + 1; adjacentRowIndex++) {

                        string adjacentRow = map[adjacentRowIndex];

                        List<int> positionsAlreadyFound = new List<int>();

                        for (int adjacentColumnIndex = columnIndex - 1; adjacentColumnIndex <= columnIndex + 1; adjacentColumnIndex++) {

                            if (Char.IsNumber(adjacentRow[adjacentColumnIndex])) {

                                List<int> adjacentColumnsWithNums = new List<int> { adjacentColumnIndex };

                                int i = adjacentColumnIndex - 1;

                                while (i >= 0 && Char.IsNumber(adjacentRow[i])) {

                                    adjacentColumnsWithNums.Add(i);

                                    i--;

                                }

                                i = adjacentColumnIndex + 1;

                                while (i < row.Length && Char.IsNumber(adjacentRow[i])) {

                                    adjacentColumnsWithNums.Add(i);

                                    i++;

                                }

                                int lowestIndex = adjacentColumnsWithNums.Min();
                                int highestIndex = adjacentColumnsWithNums.Max();

                                string numStr = adjacentRow.Substring(lowestIndex, highestIndex - lowestIndex + 1);

                                int num = int.Parse(numStr);

                                if (positionsAlreadyFound.Contains(lowestIndex)) {

                                    continue;

                                }

                                partNumbers.Add(num);

                                positionsAlreadyFound.Add(lowestIndex);

                            }

                        }

                    }

                }

            }

            return partNumbers;

        }

        private List<int> GetGearRatios(string[] map) {

            List<int> gearRatios = new List<int>();

            for (int rowIndex = 0; rowIndex < map.Length; rowIndex++) {

                string row = map[rowIndex];

                for (int columnIndex = 0; columnIndex < row.Length; columnIndex++) {

                    // Skip if part is not a gear
                    if (row[columnIndex] != '*') {

                        continue;

                    }

                    List<int> nums = new List<int>();

                    // Find numbers around part
                    for (int adjacentRowIndex = rowIndex - 1; adjacentRowIndex <= rowIndex + 1; adjacentRowIndex++) {

                        string adjacentRow = map[adjacentRowIndex];

                        List<int> positionsAlreadyFound = new List<int>();

                        for (int adjacentColumnIndex = columnIndex - 1; adjacentColumnIndex <= columnIndex + 1; adjacentColumnIndex++) {

                            if (Char.IsNumber(adjacentRow[adjacentColumnIndex])) {

                                List<int> adjacentColumnsWithNums = new List<int> { adjacentColumnIndex };

                                int i = adjacentColumnIndex - 1;

                                while (i >= 0 && Char.IsNumber(adjacentRow[i])) {

                                    adjacentColumnsWithNums.Add(i);

                                    i--;

                                }

                                i = adjacentColumnIndex + 1;

                                while (i < row.Length && Char.IsNumber(adjacentRow[i])) {

                                    adjacentColumnsWithNums.Add(i);

                                    i++;

                                }

                                int lowestIndex = adjacentColumnsWithNums.Min();
                                int highestIndex = adjacentColumnsWithNums.Max();

                                string numStr = adjacentRow.Substring(lowestIndex, highestIndex - lowestIndex + 1);

                                int num = int.Parse(numStr);

                                if (positionsAlreadyFound.Contains(lowestIndex)) {

                                    continue;

                                }

                                nums.Add(num);

                                positionsAlreadyFound.Add(lowestIndex);

                            }

                        }

                    }

                    if (nums.Count == 2) {

                        int gearRatio = nums[0] * nums[1];

                        gearRatios.Add(gearRatio);

                    }

                }

            }

            return gearRatios;

        }

        protected override string Part2() {

            string[] lines = AdventOfCode.GetInput();

            // PrintSchematic(lines);

            List<int> gearRatios = GetGearRatios(lines);

            int sumOfGearRatios = gearRatios.Sum();

            return sumOfGearRatios.ToString();

        }

        static void Main(string[] args) {

            var day = new Day3();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
