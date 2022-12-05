using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day4 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput();

            int part1 = 0;
            int part2 = 0;

            foreach (string line in input) {

                int[] firstElfSections = new int[2];
                int[] secondElfSections = new int[2];

                string[] splitLine = line.Split(',');

                (firstElfSections[0], firstElfSections[1]) = (int.Parse(splitLine[0].Split('-')[0]), int.Parse(splitLine[0].Split('-')[1]));
                (secondElfSections[0], secondElfSections[1]) = (int.Parse(splitLine[1].Split('-')[0]), int.Parse(splitLine[1].Split('-')[1]));

                if ((firstElfSections[0] <= secondElfSections[0] && firstElfSections[1] >= secondElfSections[1]) ||
                    (firstElfSections[0] >= secondElfSections[0] && firstElfSections[1] <= secondElfSections[1])) {

                    part1++;

                }

                if ((firstElfSections[1] >= secondElfSections[0] && firstElfSections[0] <= secondElfSections[1]) ||
                    (firstElfSections[0] >= secondElfSections[1] && firstElfSections[1] <= secondElfSections[1])) {

                    part2++;

                }

            }

            AdventOfCode.PrintWithColor($"\nPart 1: {part1}");
            AdventOfCode.PrintWithColor($"Part 2: {part2}");

            Console.ReadKey();

        }

    }

}
