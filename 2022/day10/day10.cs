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

            void CheckImportantCycle() {

                if (cycle == importantCycle) {

                    int signalStrength = x * cycle;

                    totalSignalStrength += signalStrength;

                    AdventOfCode.PrintWithColor($"Cycle: {cycle}\nSignal Strength: {signalStrength}\nTotal Signal Strength: {totalSignalStrength}\n", ConsoleColor.Gray);

                    importantCycle += 40;

                }

            }

            foreach (string line in input) {

                string instruction = line.Substring(0, 4);

                AdventOfCode.PrintWithColor(line.Substring(0, 4), ConsoleColor.Cyan);

                if (instruction == "noop") {

                    cycle++;

                    AdventOfCode.PrintWithColor($"Cycle: {cycle}\n", ConsoleColor.Magenta);

                    CheckImportantCycle();

                } else {

                    int v = int.Parse(line.Split(' ')[1]);

                    cycle++;

                    CheckImportantCycle();

                    cycle++;

                    x += v;

                    CheckImportantCycle();

                    AdventOfCode.PrintWithColor($"Cycle: {cycle}\nV: {v}\nX:{x}\n", ConsoleColor.Yellow);

                }

            }

            // Part 2

            x = 1;

            int position = 0;
            int rowNumber = 0;

            List<string> rows = new List<string> { string.Empty };

            void Draw() {

                if (position <= x + 1 && position >= x - 1) {

                    rows[rowNumber] += "#";

                } else {

                    rows[rowNumber] += " ";

                }

            }

            void NextPostion() {

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

                if (instruction == "addx") {

                    int v = int.Parse(line.Split(' ')[1]);

                    Draw();

                    NextPostion();

                    Draw();

                    NextPostion();

                    x += v;

                } else {

                    Draw();

                    NextPostion();

                }

            }

            AdventOfCode.PrintWithColor($"\nPart 1: {totalSignalStrength}");
            AdventOfCode.PrintWithColor("\nPart 2:\n");

            foreach (string row in rows) {

                AdventOfCode.PrintWithColor(row, ConsoleColor.Red);

            }

            Console.ReadKey();

        }

    }

}
