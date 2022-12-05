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

                    foreach (char character in line) {

                        if (character == ' ' || character == ']' || char.IsDigit(character)) {

                            Console.WriteLine(character + ": skipping");

                            continue;

                        } else if (character == '[') {

                            Console.WriteLine(character + ": incrementing stack number");

                            stackNumber++;

                        } else {

                            Console.WriteLine(character + ": adding to stack " + stackNumber);

                            stacks[stackNumber].Prepend(character);

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
