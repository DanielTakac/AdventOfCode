using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day7 {

        class Directory {

            public string name;
            public string path;

            public Dictionary<string, int> files;

            List<Directory> containedDirectories;

            public Directory() {
                
                this.name = string.Empty;
                this.path = string.Empty;
                this.files = new Dictionary<string, int>();
                this.containedDirectories = new List<Directory>();

            }

            public Directory(string name, string path) : this() {

                this.name = name;
                this.path = path;

            }

            public void AddDirectory(Directory directory) {

                if (containedDirectories.Contains(directory)) return;

                containedDirectories.Add(directory);

            }

            public void AddFile(string fileName, int fileSize) {

                if (this.Contains(fileName)) {

                    AdventOfCode.PrintWithColor($"File {fileName} already exists in {this.name}!", ConsoleColor.Red);

                    return;

                }

                files.Add(fileName, fileSize);

            }

            public bool Contains(Directory directory) {

                foreach (Directory dir in containedDirectories) {

                    if (dir.name == directory.name) return true;

                }

                return false;

            }

            public bool Contains(string fileName) {

                foreach (KeyValuePair<string, int> file in files) {

                    if (file.Key == fileName) return true;

                }

                return false;

            }

            public int GetTotalSize() {

                int size = 0;

                /*foreach (KeyValuePair<string, int> file in files) {

                    size += file.Value;

                }*/

                foreach (Directory dir in containedDirectories) {

                    //size += dir.GetTotalSize();

                    if (dir.path.Length < this.path.Length) {

                        //AdventOfCode.PrintWithColor($"{this.path} - {dir.path}", ConsoleColor.Red);

                        return 0;

                    } else {

                        //Console.WriteLine($"{this.path} - {dir.path}");

                    }

                    dir.GetTotalSize();

                }

                return size;

            }

        }

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput(path: "input.txt");

            List<Directory> directories = new List<Directory>();

            directories.Add(new Directory("/", "/"));

            string currentDirectory = "/";
            string currentPath = "/";

            int part1 = 0;

            int GetLastSlashPosition() {

                int lastSlashPosition = 0;

                for (int i = 0; i < currentPath.Length; i++) {

                    if (currentPath[i] == '/') lastSlashPosition = i;

                }

                return lastSlashPosition;

            }

            bool DirectoryExists(string name) {

                foreach (Directory dir in directories) {

                    if (dir.name == name) return true;

                }

                return false;

            }

            Directory GetDirectory(string name) {

                foreach (Directory dir in directories) {

                    if (dir.name == name) return dir;

                }

                return null;

            }

            foreach (string line in input) {

                AdventOfCode.PrintWithColor(line, ConsoleColor.Cyan);

                if (line[0] == '$') {

                    if (line.Substring(2, 2) == "cd") {

                        if (line.Substring(5, line.Length - 5) == "..") {

                            AdventOfCode.PrintWithColor($"Before .. - {currentDirectory} - {currentPath}", ConsoleColor.Magenta);

                            AdventOfCode.PrintWithColor(GetLastSlashPosition() + " - " + currentPath.Substring(GetLastSlashPosition()), ConsoleColor.White);

                            if (currentPath.Count(x => x == '/') == 1) {

                                currentPath = "/";
                                currentDirectory = "/";

                                continue;

                            }

                            currentPath = currentPath.Remove(GetLastSlashPosition());

                            currentDirectory = currentPath.Substring(GetLastSlashPosition() + 1, currentPath.Length - GetLastSlashPosition() - 1);

                            AdventOfCode.PrintWithColor($"After .. - {currentDirectory} - {currentPath}", ConsoleColor.Magenta);

                            Console.WriteLine($"Switched to parent folder: {currentPath} - {currentDirectory}");

                            continue;

                        }

                        currentDirectory = line.Substring(5, line.Length - 5);

                        AdventOfCode.PrintWithColor(currentDirectory, ConsoleColor.Yellow);

                        AdventOfCode.PrintWithColor(currentDirectory, ConsoleColor.Red);

                        if (currentPath == "/" && currentDirectory == "/") {

                            continue;

                        }

                        if (currentPath == "/") {

                            currentPath += currentDirectory;

                        } else {

                            currentPath += "/" + currentDirectory;

                        }

                        AdventOfCode.PrintWithColor(currentPath);

                        if (!DirectoryExists(currentDirectory)) {

                            directories.Add(new Directory(currentDirectory, currentPath));

                        }

                        Console.WriteLine($"Changed directory to {currentDirectory}, current path is {currentPath}");

                    } else if (line.Substring(2, 2) == "ls") {

                        Console.WriteLine("Listing all files");

                    }

                } else {

                    if (line.Substring(0, 3) == "dir") {

                        string name = line.Substring(4, line.Length - 4);

                        string path = string.Empty;

                        if (currentPath == "/") {

                            path = $"/{name}";
                        
                        } else {
                        
                            path = $"{currentPath}/{name}";
                        
                        }

                        if (!DirectoryExists(name)) {

                            directories.Add(new Directory(name, path));

                            Console.WriteLine($"Found new directory: {name} - {path}");

                        }
                        
                        Directory currentDir = GetDirectory(currentDirectory);
                        Directory newDir = GetDirectory(name);

                        if (currentDir.Contains(newDir)) continue;

                        currentDir.AddDirectory(newDir);

                        Console.WriteLine($"Adding the found directory to {currentDirectory}");

                    } else if (char.IsDigit(line[0])) {

                        string[] splitLine = line.Split(' ');

                        string fileName = splitLine[1];
                        int fileSize = int.Parse(splitLine[0]);

                        if (!GetDirectory(currentDirectory).Contains(fileName)) {

                            GetDirectory(currentDirectory).AddFile(fileName, fileSize);

                            Console.Write("New ");

                        }

                        Console.WriteLine($"File {fileName} in {currentDirectory} has a size of {fileSize}");

                    }

                }

            }

            Console.WriteLine();

            foreach (Directory dir in directories) {

                Console.WriteLine($"Get total size of {dir.path}");

                int size = dir.GetTotalSize();

                break;

                if (size <= 100000) {

                    part1 += size;

                }

                AdventOfCode.PrintWithColor(part1.ToString(), ConsoleColor.Red);

            }

            AdventOfCode.PrintWithColor($"Part 1: {part1}");

            Console.ReadKey();

        }

    }

}
