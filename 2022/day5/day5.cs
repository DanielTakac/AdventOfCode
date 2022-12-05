using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day5 {

    class Day5 {

        static void Main(string[] args) {

            string path = @"input.txt";

            string[] input = File.ReadAllLines(path);

            List<List<char>> stacks = new List<List<char>>();

            for (int i = 1; i < 10; i++) stacks.Add(new List<char>());

            foreach (string line in input) {

                void InsertStacksFromInput() {

                    if (line.Contains("move")) return;

                    int stackNumber = -1;

                    for (int i = 0; i < line.Count(); i++) {

                        // Extremely overcomplicated way of checking if there isn't a crate
                        if (i - 1 >= 0 && i + 1 < line.Count() && line.Substring(i - 1, 3) == "   ") {

                            Console.WriteLine(line[i] + ": empty space, incrementing stack number");

                            stackNumber++;

                            i += 2;

                        } else if (line[i] == '[') {

                            Console.WriteLine(line[i] + ": incrementing stack number");

                            stackNumber++;

                        } else if (line[i] == ' ' || line[i] == ']' || char.IsDigit(line[i])) {
                            
                            Console.WriteLine(line[i] + ": skipping");

                            continue;

                        } else {

                            Console.WriteLine(line[i] + ": adding to stack " + (stackNumber + 1));

                            stacks[stackNumber].Add(line[i]);

                        }

                    }

                }

                InsertStacksFromInput();

                

            }

            int j = 1;

            foreach (List<char> stack in stacks) {

                Console.Write($"\nStack {j}: ");

                foreach (char crate in stack) {

                    Console.Write($"[{crate}] ");

                }

                j++;

            }

            Console.ReadKey();

        }

    }

}
