using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day10 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput(path: "input.txt");

            // input = new string[] { "noop", "addx 3", "addx -5" };

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

            AdventOfCode.PrintWithColor($"Cycle: {cycle}");
            AdventOfCode.PrintWithColor($"X: {x}");
            AdventOfCode.PrintWithColor($"Part 1: {totalSignalStrength}");

            Console.ReadKey();

        }

    }

}
