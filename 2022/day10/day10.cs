using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day10 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput();

            int totalSignalStrength = 0;
            int importantCycle = 20;
            int cycle = 1;
            int x = 1;

            int position = 0;
            int rowNumber = 0;

            List<string> rows = new List<string> { string.Empty };

            void CheckImportantCycle() {

                if (cycle == importantCycle) {

                    int signalStrength = x * cycle;

                    totalSignalStrength += signalStrength;

                    importantCycle += 40;

                }

            }

            void Draw() {

                if (position <= x + 1 && position >= x - 1) {

                    rows[rowNumber] += "#";

                } else {

                    rows[rowNumber] += " ";

                }

            }

            void NextPosition() {

                if (position == 39) {

                    rows.Add(string.Empty);

                    rowNumber++;

                    position = 0;

                } else {

                    position++;

                }

            }

            foreach (string line in input) {

                string instruction = line.Substring(0, 4);

                if (instruction == "noop") {

                    cycle++;

                    CheckImportantCycle();

                    Draw();

                    NextPosition();

                } else {

                    int v = int.Parse(line.Split(' ')[1]);

                    cycle++;

                    CheckImportantCycle();

                    Draw();

                    NextPosition();

                    cycle++;

                    Draw();

                    NextPosition();

                    x += v;

                    CheckImportantCycle();

                }

            }

            AdventOfCode.PrintWithColor($"Part 1: {totalSignalStrength}");
            AdventOfCode.PrintWithColor("\nPart 2:\n");

            foreach (string row in rows) {

                AdventOfCode.PrintWithColor(row, ConsoleColor.Red);

            }

            Console.ReadKey();

        }

    }

}
