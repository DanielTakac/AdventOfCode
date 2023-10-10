using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day8 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput();

            // [ horizontal, depth ] Part 1
            int[] position1 = new int[] { 0, 0 };

            // [ horizontal, depth, aim ] Part 2
            int[] position2 = new int[] { 0, 0, 0 };

            for (int i = 0; i < input.Length; i++) {

                string[] splitInput = input[i].Split(' ');

                string instruction = splitInput[0];
                int amount = Convert.ToInt32(splitInput[1]);

                // Part 1
                switch (instruction) {

                    case "forward":
                        position1[0] += amount;
                        break;

                    case "up":
                        position1[1] -= amount;
                        break;

                    case "down":
                        position1[1] += amount;
                        break;

                }

                // Part 2
                switch (instruction) {

                    case "forward":
                        position2[0] += amount;
                        position2[1] += position2[2] * amount;
                        break;

                    case "up":
                        position2[2] -= amount;
                        break;

                    case "down":
                        position2[2] += amount;
                        break;

                }

            }

            Console.WriteLine("Part 1:");
            Console.WriteLine($"Horizontal position: {position1[0]}");
            Console.WriteLine($"Depth: {position1[1]}");

            Console.WriteLine("\nPart 2:");
            Console.WriteLine($"Horizontal position: {position2[0]}");
            Console.WriteLine($"Depth: {position2[1]}");

            int part1 = position1[0] * position1[1];
            int part2 = position2[0] * position2[1];

            AdventOfCode.PrintWithColor($"\nPart 1: {part1}");
            AdventOfCode.PrintWithColor($"Part 2: {part2}");

            Console.ReadKey();

        }

    }

}
