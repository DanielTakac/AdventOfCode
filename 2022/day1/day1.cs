using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1 {

    class Day1 {
        
        static void Main(string[] args) {

            string path = @"input.txt";
            
            string[] readText = File.ReadAllLines(path);

            List<int> elfCalories = new List<int>();

            int i = 0;

            int tempCalories = 0;

            foreach (string line in readText) {

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

            int maxCalories1 = elfCalories[0];
            int maxCalories2 = elfCalories[1];
            int maxCalories3 = elfCalories[2];

            Console.WriteLine("\nMax calories #1: " + maxCalories1);
            Console.WriteLine("Max calories #2: " + maxCalories2);
            Console.WriteLine("Max calories #3: " + maxCalories3);

            int totalTop3 = maxCalories1 + maxCalories2 + maxCalories3;
            
            Console.WriteLine("\nTotal calories of top 3: " + totalTop3);

            Console.ReadKey();

        }

    }

}
