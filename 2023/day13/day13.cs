using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day13 : Day {

        protected override string Part1() {

            string[] input = AdventOfCode.GetInput("example.txt");

            List<string[]> patterns = [];

            List<string> lines = [];

            for (int i = 0; i < input.Length; i++) {

                if (input[i].Length == 0 || i == input.Length - 1) {

                    patterns.Add(lines.ToArray());
                    lines = [];

                } else {

                    lines.Add(input[i]);

                }

            }

            foreach (string[] pattern in patterns) {

                int[] rows = GetReflectedRows(pattern);
                int[] cols = GetReflectedCols(pattern);

                for (int col = 0; col < pattern[0].Length; col++) {

                    if (cols.Contains(col - 1)) {

                        AdventOfCode.PrintWithColor("<", ConsoleColor.Cyan, false);

                    } else if (cols.Contains(col)) {

                        AdventOfCode.PrintWithColor(">", ConsoleColor.Cyan, false);

                    } else {

                        Console.Write(" ");

                    }

                }

                Console.WriteLine();

                for (int row = 0; row < pattern.Length; row++) {

                    Console.Write(pattern[row]);

                    if (rows.Contains(row - 1)) {

                        AdventOfCode.PrintWithColor(" \\", ConsoleColor.Cyan);

                    } else if (rows.Contains(row)) {

                        AdventOfCode.PrintWithColor(" /", ConsoleColor.Cyan);

                    } else {

                        Console.WriteLine();

                    }

                }

                Console.Write("\nReflected rows: ");
                foreach (int row in rows) AdventOfCode.PrintWithColor(row + " ", ConsoleColor.Cyan, false);
                Console.WriteLine("\n");

            }

            return string.Empty;

        }

        private static int[] GetReflectedRows(string[] pattern) {

            List<int> reflectedRows = [];

            for (int i = 0; i < pattern.Length - 1; i++) {

                bool mirrored = true;

                for (int j = 0; j < pattern[0].Length; j++) {

                    if (pattern[i][j] != pattern[i + 1][j]) {

                        mirrored = false;

                    }

                }
                if (mirrored) {

                    reflectedRows.Add(i);

                }

            }

            return reflectedRows.ToArray();

        }

        private static int[] GetReflectedCols(string[] pattern) {

            List<int> reflectedCols = [];

            return reflectedCols.ToArray();

        }

        protected override string Part2() {

            return string.Empty;

        }

        static void Main(string[] args) {

            var day = new Day13();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
