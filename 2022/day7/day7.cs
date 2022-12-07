using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day7 {

        class Directory {

            string name;
            string path;
            int size;

            List<Directory> containedDirectories;

            public Directory() {

                string name = string.Empty;
                string path = string.Empty;
                int size = 0;

            }

            public Directory(string name, string path, int size) : this() {

                this.name = name;
                this.path = path;
                this.size = size;

            }

            public void AddDirectory(Directory directory) {

                if (containedDirectories.Contains(directory)) return;

                containedDirectories.Add(directory);

            }

        }

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput(path: "demo.txt");

            List<Directory> directories = new List<Directory>();

            directories.Add(new Directory("/", "/", 0));

            string currentDirectory = "/";
            string currentPath = "/";

            int part1 = 0;

            int GetLastSlashPosition(string text = currentPath) {

                int lastSlashPosition = 0;

                for (int i = 0; i < text.Length; i++) {

                    if (text[i] == '/')
                        lastSlashPosition = i;

                }

                return lastSlashPosition;

            }

            foreach (string line in input) {

                if (line[0] == '$') {

                    if (line.Substring(2, 2) == "cd") {

                        if (line.Substring(5, line.Length - 5) == "..") {

                            currentPath.Remove(GetLastSlashPosition() - 1);

                            currentDirectory = currentPath.Substring(GetLastSlashPosition(), currentPath.Length - GetLastSlashPosition());

                            Console.WriteLine($"Switched to parent folder: {currentPath} - {currentDirectory}");

                            continue;

                        }

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
