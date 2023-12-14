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

            foreach (string line in input) {

                if (line.Length == 0) {

                    patterns.Add(lines.ToArray());
                    lines = [];

                } else {

                    lines.Add(line);

                }

            }

            foreach (string[] pattern in patterns) {

                int[] rows = GetReflectedRows(pattern);

                Console.Write("Reflected rows: ");
                foreach (int row in rows) AdventOfCode.PrintWithColor(row + " ", ConsoleColor.Cyan, false);
                Console.WriteLine();

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
