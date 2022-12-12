using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode {

    class Day12 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput(path: "demo.txt");

            int[] startPos = new int[2];
            int[] endPos = new int[2];

            Dictionary<int[], bool> visitedPositions = new Dictionary<int[], bool>();

            int GetHeight(char character) {

                if (character == 'S') {

                    return 0;
                    
                } else if (character == 'E') {

                    return 25;

                } else {

                    return (int)character - 97;

                }
                
            }

            void GetNeighbors(int x, int y) {

                
                
            }
            
            for (int x = 0; x < input.Length; x++) {

                for (int y = 0; y < input[x].Length; y++) {

                    if (input[x][y] == 'S') {

                        startPos[0] = x;
                        startPos[1] = y;

                    } else if (input[x][y] == 'E') {

                        endPos[0] = x;
                        endPos[1] = y;

                    }

                }

            }

            Console.ReadKey();

        }

    }

}
