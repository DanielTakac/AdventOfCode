using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day13 : Day {

        protected override string Part1() {

            string[] input = AdventOfCode.GetInput();

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

            int finalCols = 0;
            int finalRows = 0;

            foreach (string[] pattern in patterns) {

                int[] rows = GetReflectedRows(pattern);
                int[] cols = GetReflectedCols(pattern);

                foreach (int row in rows) {

                    finalRows += 100 * (row + 1);

                }

                foreach (int col in cols) {

                    finalCols += col + 1;

                }

                // Debugging

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
                Console.Write("\nReflected columns: ");
                foreach (int col in cols) AdventOfCode.PrintWithColor(col + " ", ConsoleColor.Cyan, false);
                Console.WriteLine("\n");

            }

            int finalAnsa = finalRows + finalCols;

            return finalAnsa.ToString();

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

                    bool actuallyMirrored = true;

                    int rowVec = 1;

                    while (actuallyMirrored) {

                        int row1 = i + rowVec + 1;
                        int row2 = i - rowVec;

                        if (row1 >= pattern.Length || row2 < 0) break;

                        for (int j = 0; j < pattern[0].Length; j++) {

                            if (pattern[row1][j] != pattern[row2][j]) {

                                actuallyMirrored = false;
                                break;

                            }

                        }

                        rowVec++;

                    }

                    if (actuallyMirrored) {

                        reflectedRows.Add(i);

                    }

                }

            }

            return reflectedRows.ToArray();

        }

        private static int[] GetReflectedCols(string[] pattern) {

            List<int> reflectedCols = [];

            for (int j = 0; j < pattern[0].Length - 1; j++) {

                bool mirrored = true;

                for (int i = 0; i < pattern.Length; i++) {

                    if (pattern[i][j] != pattern[i][j + 1]) {

                        mirrored = false;

                    }

                }

                if (mirrored) {

                    bool actuallyMirrored = true;

                    int colVec = 1;

                    while (actuallyMirrored) {

                        int col1 = j + colVec + 1;
                        int col2 = j - colVec;

                        if (col1 >= pattern[0].Length || col2 < 0) break;

                        for (int i = 0; i < pattern.Length; i++) {
                            if (pattern[i][col1] != pattern[i][col2]) {

                                actuallyMirrored = false;
                                break;

                            }

                        }

                        colVec++;

                    }

                    if (actuallyMirrored) {

                        reflectedCols.Add(j);

                    }

                }

            }

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
