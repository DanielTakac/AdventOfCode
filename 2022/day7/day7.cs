using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day7 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput(path: "demo.txt");

            Dictionary<string, int> directorySizes = new Dictionary<string, int>();

            directorySizes.Add("/", 0);

            string currentDirectory = "/";

            bool directoryOutputMode = false;

            int part1 = 0;

            foreach (string line in input) {

                if (directoryOutputMode) {

                    if (line[0] == '$') {

                        directoryOutputMode = false;

                        continue;

                    }

                    

                }

                if (line[0] == '$') {

                    if (line.Substring(2, 2) == "cd") {

                        currentDirectory = line.Substring(5, line.Length - 5);

                        if (!directorySizes.ContainsKey(line.Substring(5, line.Length - 5))) {

                            directorySizes.Add(line.Substring(5, line.Length - 5), 0);

                        }

                        Console.WriteLine($"Changed directory to {currentDirectory}");

                    } else if (line.Substring(2, 2) == "ls") {

                        Console.WriteLine("Listing all files");

                    }

                } else {

                    if (line.Substring(0, 3) == "dir") {

                        if (directorySizes.ContainsKey(line.Substring(4, line.Length - 4))) {

                            continue;

                        }

                        directorySizes.Add(line.Substring(4, line.Length - 4), 0);

                        Console.WriteLine($"Found new directory: {line.Substring(4, line.Length - 4)}");

                    } else if (char.IsDigit(line[0])) {

                        string[] splitLine = line.Split(' ');

                        directorySizes[currentDirectory] += int.Parse(splitLine[0]);

                        Console.WriteLine($"File {splitLine[1]} in {currentDirectory} has a size of {splitLine[0]}");

                    }

                }

            }

            Console.WriteLine();

            foreach (KeyValuePair<string, int> directory in directorySizes) {

                Console.WriteLine($"{directory.Key} - {directory.Value}");

                if (directory.Value < 100000) {

                    part1 += directory.Value;

                }

            }

            AdventOfCode.PrintWithColor($"Part 1: {part1}");

            Console.ReadKey();

        }

    }

}
