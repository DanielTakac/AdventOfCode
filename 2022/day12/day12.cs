﻿using System;
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

            int Height(char character) {

                if (character == 'S') {

                    return 0;
                    
                } else if (character == 'E') {

                    return 25;

                } else {

                    return (int)character - 97;

                }
                
            }

            int[] Neighbors(int x, int y) {

                int currentHeight = Height(input[x][y]);

                int[,] neighbors = new int[,] { { x + 1, y }, { x - 1, y }, { x, y + 1 }, { x, y - 1 } };

                for (int i = 0; i < neighbors.Length; i++) {

                    if (!(neighbors[i, 0] >= 0 && neighbors[i, 0] < input.Length &&
                          neighbors[i, 1] >= 0 && neighbors[i, 1] < input[0].Length)) {

                        continue;

                    }

                    if (Height(input[neighbors[i, 0]][neighbors[i, 1]]) <= currentHeight) {

                        return new int[] { neighbors[i, 0], neighbors[i, 1] };

                    }

                }

                return null;

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

            // Dijkstra's Algorithm

            var nodes = new List<Node>();

            for (int i = 0; i < input.Length; i++) {

                for (int j = 0; j < input[i].Length; j++) {

                    nodes.Add(new Node(new int[] { i, j }));

                }

            }

            var queue = new List<Node>() { new Node(new int[] { 0, 0 }, 0) };

            while (true) {

                

            }

            Console.WriteLine(startPos[0] + " " + startPos[1]);
            Console.WriteLine(endPos[0] + " " + endPos[1]);

            Console.ReadKey();

        }

        class Node {

            public int[] Position { get; set; }
            public int Distance { get; set; }
            public bool Visited { get; set; }

            public Node(int[] position) {

                Position = position;
                Visited = false;

            }

            public Node(int[] position, int distance) {

                Position = position;
                Distance = distance;
                Visited = false;

            }

            public Node(int[] position, int distance, bool visited) {

                Position = position;
                Distance = distance;
                Visited = visited;

            }

        }

    }

}
