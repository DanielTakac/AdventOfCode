using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day5 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput();

            List<List<char>> stacks = new List<List<char>>();
            List<List<char>> stacks2 = new List<List<char>>();

            for (int i = 1; i < 10; i++) stacks.Add(new List<char>());
            for (int i = 1; i < 10; i++) stacks2.Add(new List<char>());

            bool reversed = false;

            Console.Write("Part 1 or 2?\n>>");
            int chosenPart = Convert.ToInt32(Console.ReadLine());

            foreach (string line in input) {

                void InsertStacksFromInput() {

                    // If the current line contains "move",
                    // all the stacks have already been inserted so it skips it
                    if (line.Contains("move")) {

                        // Only reverses the stacks once
                        if (!reversed) {

                            for (int i = 0; i < stacks.Count(); i++) {

                                stacks[i].Reverse();

                                reversed = true;

                            }

                        }

                        return;

                    }

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

                        } else if (char.IsDigit(line[i])) {

                            Console.WriteLine("Finished inserting stacks!\n");

                            return;

                        } else if (line[i] == ' ' || line[i] == ']') {

                            Console.WriteLine(line[i] + ": skipping");

                            continue;

                        } else {

                            Console.WriteLine(line[i] + ": adding to stack " + (stackNumber + 1));

                            stacks[stackNumber].Add(line[i]);

                        }

                    }

                }

                InsertStacksFromInput();

                if (!line.Contains("move")) continue;

                int[] coolArray = new int[3];

                int counter = 0;

                for (int i = 0; i < line.Count(); i++) {

                    if (char.IsDigit(line[i])) {

                        string temp = string.Empty;

                        while (i < line.Count() && char.IsDigit(line[i])) {

                            temp += line[i];

                            i++;

                        }

                        coolArray[counter] = int.Parse(temp);

                        counter++;

                    }

                }

                if (chosenPart != 1 && chosenPart != 2) return;

                if (chosenPart == 1) {

                    for (int i = 0; i < coolArray[0]; i++) {

                        stacks[coolArray[2] - 1].Add(stacks[coolArray[1] - 1][stacks[coolArray[1] - 1].Count() - 1]);

                        stacks[coolArray[1] - 1].RemoveAt(stacks[coolArray[1] - 1].Count() - 1);

                    }

                } else {

                    List<char> tempList = new List<char>();

                    for (int i = 0; i < coolArray[0]; i++) {

                        tempList.Add(stacks[coolArray[1] - 1][stacks[coolArray[1] - 1].Count() - 1]);

                        stacks[coolArray[1] - 1].RemoveAt(stacks[coolArray[1] - 1].Count() - 1);

                    }

                    tempList.Reverse();

                    foreach (char character in tempList) {

                        stacks[coolArray[2] - 1].Add(character);

                        Console.WriteLine(character);

                    }

                }

            }

            int j = 1;

            foreach (List<char> stack in stacks) {

                Console.Write($"\nStack {j}: ");

                foreach (char crate in stack) {

                    Console.Write($"[{crate}] ");

                }

                j++;

            }

            string part1 = string.Empty;

            for (int i = 0; i < stacks.Count(); i++) {

                part1 += stacks[i][stacks[i].Count() - 1];

            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\nPart {chosenPart}: {part1}");
            Console.ResetColor();

            Console.ReadKey();

        }

    }

}
