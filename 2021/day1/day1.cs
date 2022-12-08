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
            
            for (int i = 1; i < input.Length; i++) {

                // Part 1

                int currentMeasurement = int.Parse(input[i]);
                int previousMeasurement = int.Parse(input[i - 1]);

                if (currentMeasurement > previousMeasurement) part1++;

                // Part 2

                if (i >= input.Length - 2) continue;

                int currentWindow = int.Parse(input[i]) + int.Parse(input[i + 1]) + int.Parse(input[i + 2]);
                int previousWindow = int.Parse(input[i - 1]) + int.Parse(input[i]) + int.Parse(input[i + 1]);

                if (currentWindow > previousWindow) part2++;

            }

            AdventOfCode.PrintWithColor($"Part 1: {part1}");
            AdventOfCode.PrintWithColor($"Part 2: {part2}");
            
            Console.ReadKey();

        }

    }

}
