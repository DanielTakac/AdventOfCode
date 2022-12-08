using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day8 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput();

            int previousMeasurement = 0;

            int part1 = 0;
            
            foreach (string line in input) {

                int currentMeaserement = int.Parse(line);

                Console.Write(currentMeaserement);

                if (previousMeasurement == 0) {

                    Console.WriteLine(" (N/A - no previous measurement)");
                    
                } else if (currentMeaserement > previousMeasurement) {

                    Console.WriteLine(" (increased)");

                    part1++;

                } else {

                    Console.WriteLine(" (decreased)");

                }

                previousMeasurement = currentMeaserement;

            }

            AdventOfCode.PrintWithColor($"\nPart 1: {part1}");
            
            Console.ReadKey();

        }

    }

}
