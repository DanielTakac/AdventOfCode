using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day12 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput(path: "demo.txt");

            void CheckAllPaths(int xPos, int yPos) {

                

            }

            for (int x = 0; x < input.Length; x++) {

                for (int y = 0; y < input[x].Length; y++) {

                    if (input[x][y] == 'S' || input[x][y] == 'E') {

                        AdventOfCode.PrintWithColor("TEST", ConsoleColor.Red);

                        continue;

                    }

                    CheckAllPaths(x, y);

                }

            }

            Console.ReadKey();

        }

    }

}
