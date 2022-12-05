using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day1 {
        
        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput();

            List<int> elfCalories = new List<int>();

            int i = 0;

            int tempCalories = 0;

            foreach (string line in input) {

                if (line == " " || line == "") {

                    elfCalories.Add(tempCalories);

                    Console.WriteLine("Elf " + i + " has " + tempCalories + " calories.");

                    tempCalories = 0;

                    i++;
                    
                    continue;
                    
                }

                tempCalories += int.Parse(line);

            }

            elfCalories.Sort();
            elfCalories.Reverse();

            Console.WriteLine("\nMax calories #1: " + elfCalories[0]);
            Console.WriteLine("Max calories #2: " + elfCalories[1]);
            Console.WriteLine("Max calories #3: " + elfCalories[2]);

            int totalTop3 = elfCalories[0] + elfCalories[1] + elfCalories[2];

            AdventOfCode.PrintWithColor($"\nPart 1: {elfCalories[0]}");
            AdventOfCode.PrintWithColor($"Part 2: {totalTop3}");

            Console.ReadKey();

        }

    }

}
