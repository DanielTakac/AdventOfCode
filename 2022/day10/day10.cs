using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day10 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput(path: "input.txt");

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

            foreach (string line in input) {

                string instruction = line.Substring(0, 4);

                if (instruction == "addx") {

                    int v = int.Parse(line.Split(' ')[1]);

                    Console.WriteLine($"\nInstruction: {instruction}");
                    Console.WriteLine($"Position: {position} - X: {x} - V: {v}");

                    if (position <= x + 1 && position >= x - 1) {

                        rows[rowNumber] += "#";

                    } else {

                        rows[rowNumber] += " ";

                    }

                    if (position is 39 or 79 or 119 or 159 or 199 or 139) {

                        rows.Add(string.Empty);

                        rowNumber++;

                        position = 0;

                    } else {

                        position++;

                    }

                    Console.WriteLine($"Position: {position} - X: {x} - V: {v}");

                    if (position <= x + 1 && position >= x - 1) {

                        rows[rowNumber] += "#";

                    } else {

                        rows[rowNumber] += " ";

                    }

                    if (position is 39 or 79 or 119 or 159 or 199 or 239) {

                        rows.Add(string.Empty);

                        rowNumber++;

                        position = 0;

                    } else {

                        position++;

                    }

                    x += v;

                } else {

                    Console.WriteLine($"\nInstruction: noop");
                    Console.WriteLine($"Position: {position} - X: {x}");

                    if (position <= x + 1 && position >= x - 1) {

                        rows[rowNumber] += "#";

                    } else {

                        rows[rowNumber] += " ";

                    }

                    if (position is 39 or 79 or 119 or 159 or 199 or 139) {

                        rows.Add(string.Empty);

                        rowNumber++;

                        position = 0;

                    } else {

                        position++;

                    }

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
