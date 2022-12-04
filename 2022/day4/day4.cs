using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4 {

    class Day4 {

        static void Main(string[] args) {

            string path = @"input.txt";

            string[] input = File.ReadAllLines(path);

            int part1 = 0;

            foreach (string line in input) {

                int[] firstElfSections = new int[2];
                int[] secondElfSections = new int[2];

                string[] splitLine = line.Split(',');

                (firstElfSections[0], firstElfSections[1]) = (int.Parse(splitLine[0].Split('-')[0]), int.Parse(splitLine[0].Split('-')[1]));
                (secondElfSections[0], secondElfSections[1]) = (int.Parse(splitLine[1].Split('-')[0]), int.Parse(splitLine[1].Split('-')[1]));

                Console.ResetColor();

                if ((firstElfSections[0] <= secondElfSections[0] && firstElfSections[1] >= secondElfSections[1]) ||
                    (firstElfSections[0] >= secondElfSections[0] && firstElfSections[1] <= secondElfSections[1])) {

                    Console.ForegroundColor = ConsoleColor.Magenta;

                    part1++;

                }

                Console.WriteLine($"\nFirst Elf: {firstElfSections[0]}-{firstElfSections[1]}\nSecond Elf: {secondElfSections[0]}-{secondElfSections[1]}\n");

            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nPart 1: {part1}");
            Console.ResetColor();

            Console.ReadKey();

        }

    }

}
