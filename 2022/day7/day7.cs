using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day7 {

        class Directory {

            public string name;

            public Directory parent;

            public Dictionary<string, int> files;

            public List<Directory> containedDirs;

            public Directory() {
                
                this.name = string.Empty;
                this.files = new Dictionary<string, int>();
                this.containedDirs = new List<Directory>();

            }

            public Directory(string name) : this() {

                this.name = name;

            }

            public void AddChild(Directory directory) {

                if (containedDirs.Contains(directory)) return;

                containedDirs.Add(directory);

                directory.parent = this;

            }

            public void AddFile(string fileName, int fileSize) {

                if (this.Contains(fileName)) {

                    AdventOfCode.PrintWithColor($"File {fileName} already exists in {this.name}!", ConsoleColor.Red);

                    return;

                }

                files.Add(fileName, fileSize);

            }

            public bool Contains(Directory directory) {

                foreach (Directory dir in containedDirs) {

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

                foreach (KeyValuePair<string, int> file in files) {

                    size += file.Value;

                }

                foreach (Directory dir in containedDirs) {

                    size += dir.GetTotalSize();

                }

                return size;

            }

        }

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput(path: "input.txt");

            List<Directory> directories = new List<Directory>();

            Directory currentDir = new Directory("/");

            Directory root = currentDir;

            directories.Add(root);

            int part1 = 0;

            void ChangeDirectory(string dir) {

                if (dir == "..") {

                    currentDir = currentDir.parent;

                    return;

                }

                if (dir == "/") {

                    currentDir = root;

                    return;

                }

                if (!currentDir.Contains(dir)) {

                    var newDir = new Directory(dir);

                    currentDir.AddChild(newDir);

                    directories.Add(newDir);

                }

                currentDir = currentDir.containedDirs.Find(x => x.name == dir);

            }

            foreach (string line in input) {

                AdventOfCode.PrintWithColor(line, ConsoleColor.Cyan);

                if (line[0] == '$') {

                    if (!(line.Substring(2, 2) == "cd")) continue;

                    string dir = line.Substring(5, line.Length - 5);

                    ChangeDirectory(dir);

                } else {

                    if (!char.IsDigit(line[0])) continue;

                    int size = int.Parse(line.Split(' ')[0]);
                    string fileName = line.Split(' ')[1];

                    if (currentDir.Contains(fileName)) continue;

                    currentDir.AddFile(fileName, size);

                }

            }

            foreach (Directory dir in directories) {

                Console.WriteLine(dir.name);

                int size = dir.GetTotalSize();

                if (size <= 100000) {

                    part1 += size;

                }

            }

            AdventOfCode.PrintWithColor($"Part 1: {part1}");

            Console.ReadKey();

        }

    }

}
