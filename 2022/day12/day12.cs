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

            var visitedNodes = new Dictionary<int[], bool>();

            bool IsVisited(Node node) {

                foreach (KeyValuePair<int[], bool> visitedNode in visitedNodes) {

                    if (visitedNode.Key[0] == node.X && visitedNode.Key[1] == node.Y) {

                        return true;

                    }

                }

                return false;

            }

            var queue = new List<Node>() { new Node(0, 0, 0) };

            while (true) {

                foreach (Node coolNode in queue) AdventOfCode.PrintWithColor(coolNode.X + ", " + coolNode.Y + ", " + coolNode.Distance + ", " + coolNode.Height + ", " + IsVisited(coolNode), ConsoleColor.Red);

                Node node = queue.OrderBy(n => n.Distance).First();

                Node newNode = new Node(node.X, node.Y, node.Distance);

                queue.Remove(node);

                if (IsVisited(newNode)) continue;

                visitedNodes.Add(new int[] { newNode.X, newNode.Y }, true);

                if (newNode.X == endPos[0] && newNode.Y == endPos[1]) {

                    AdventOfCode.PrintWithColor(newNode.Distance.ToString());
                    break;

                }

                foreach (var neighbor in newNode.Neighbors(new List<Node>())) {

                    neighbor.Distance++;

                    queue.Add(neighbor);

                    AdventOfCode.PrintWithColor(neighbor.X + ", " + neighbor.Y + ", " + neighbor.Distance + ", " + neighbor.Height + ", " + IsVisited(neighbor), ConsoleColor.Yellow); 

                }

            }

            Console.ReadKey();

        }

        class Node {

            public int X { get; set; }
            public int Y { get; set; }
            public int Distance { get; set; }
            public int Height { get; set; }

            public Node(int x, int y) {

                X = x;
                Y = y;

                Height = GetHeight();

            }

            public Node(int x, int y, int distance) {

                X = x;
                Y = y;

                Distance = distance;

                Height = GetHeight();

            }

            public Node(int x, int y, int distance, bool visited) {

                X = x;
                Y = y;
                
                Distance = distance;

                Height = GetHeight();

            }

            private int GetHeight() {

                string[] input = AdventOfCode.GetInput(path: "demo.txt");

                if (!(X >= 0 && X < input.Length && Y >= 0 && Y < input[0].Length)) {

                    return -1;

                }

                AdventOfCode.PrintWithColor(X + " - " + Y, ConsoleColor.Cyan);

                char character = input[this.X][this.Y];

                AdventOfCode.PrintWithColor(character.ToString(), ConsoleColor.Cyan);

                if (character == 'S') {

                    AdventOfCode.PrintWithColor(0.ToString(), ConsoleColor.Cyan);
                    return 0;

                } else if (character == 'E') {

                    AdventOfCode.PrintWithColor(25.ToString(), ConsoleColor.Cyan);
                    return 25;

                } else {

                    AdventOfCode.PrintWithColor(((int)character - 97).ToString(), ConsoleColor.Cyan);
                    return (int)character - 97;

                }

            }

            public List<Node> Neighbors(List<Node> neighbors) {

                string[] input = AdventOfCode.GetInput(path: "demo.txt");

                Node[] potentialNeighbors = new Node[] {
                    new Node(X + 1, Y),
                    new Node(X - 1, Y),
                    new Node(X, Y + 1),
                    new Node(X, Y - 1)
                };

                bool NeighborAlreadyExists(int i) {

                    for (int j = 0; j < neighbors.Count; j++) {

                        if (neighbors[j].X == potentialNeighbors[i].X &&
                            neighbors[j].Y == potentialNeighbors[j].Y) {

                            return true;

                        }

                    }

                    return false;

                }

                for (int i = 0; i < potentialNeighbors.Length; i++) {

                    if (NeighborAlreadyExists(i)) continue;

                    if (!(potentialNeighbors[i].X >= 0 && potentialNeighbors[i].X < input.Length &&
                          potentialNeighbors[i].Y >= 0 && potentialNeighbors[i].Y < input[0].Length)) {

                        continue;

                    }

                    if (potentialNeighbors[i].Height <= this.Height) {

                        neighbors.Add(potentialNeighbors[i]);

                    }

                }

                return neighbors;

            }

        }

    }

}
