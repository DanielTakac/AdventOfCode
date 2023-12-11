using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day11 : Day {

        protected override string Part1() {

            List<string> map = AdventOfCode.GetInput("example.txt").ToList();

            foreach (string line in map) Console.WriteLine(line);

            Console.WriteLine();

            PrintMap(map);

            Console.WriteLine();

            List<string> expandedMap = ExpandMap(map);

            PrintMap(expandedMap);



            return string.Empty;

        }

        private List<int[]> GetGalaxies(List<string> map) {

            List<int[]> galaxies = [];

            for (int i = 0; i < map.Count; i++) {

                for (int j = 0; j < map[i].Length; j++) {

                    if (map[i][j] == '#') {

                        galaxies.Add([i, j]);

                    }

                }

            }

            return galaxies;

        }

        private void PrintMap(List<string> map) {

            int counter = 1;

            for (int i = 0; i < map.Count; i++) {

                for (int j = 0; j < map[i].Length; j++) {

                    if (map[i][j] == '#') {

                        AdventOfCode.PrintWithColor(counter, ConsoleColor.Yellow, false);

                        counter++;

                    } else {

                        Console.Write(map[i][j]);

                    }

                }

                Console.WriteLine();

            }

        }

        private List<string> ExpandMap(List<string> map) {

            List<int[]> galaxies = GetGalaxies(map);

            // Clone map
            List<string> expandedMap = new List<string>(map);

            string emptyRow = "";

            for (int i = 0; i < expandedMap[0].Length; i++) {

                emptyRow += ".";

            }

            // Expand rows
            for (int row = 0; row < expandedMap.Count; row++) {

                // If there are no galaxies on this row
                if (!galaxies.Any(x => x[0] == row)) {

                    expandedMap.Insert(row, emptyRow);

                    // Move all galaxies up by one
                    foreach (int[] galaxy in galaxies) {

                        if (galaxy[0] > row) {

                            galaxy[0]++;

                        }

                    }

                    row++;

                }

            }

            // Expand columns
            for (int column = 0; column < expandedMap[0].Length; column++) {

                // If there are no galaxies on this column
                if (!galaxies.Any(x => x[1] == column)) {

                    // Insert a column at each row
                    for (int row = 0; row < expandedMap.Count; row++) {

                        expandedMap[row] = expandedMap[row].Insert(column, ".");

                    }

                    // Move all galaxies up by one
                    foreach (int[] galaxy in galaxies) {

                        if (galaxy[1] > column) {

                            galaxy[1]++;

                        }

                    }

                    column++;

                }

            }

            return expandedMap;

        }

        protected override string Part2() {

            return string.Empty;

        }

        static void Main(string[] args) {

            var day = new Day11();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
