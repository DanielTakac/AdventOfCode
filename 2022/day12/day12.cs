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

            var nodes = new List<Node>();

            for (int i = 0; i < input.Length; i++) {

                for (int j = 0; j < input[i].Length; j++) {

                    nodes.Add(new Node(i, j));

                }

            }

            AdventOfCode.PrintWithColor(nodes.Count.ToString());

            var queue = new List<Node>() { new Node(0, 0, 0) };

            while (true) {

                Node node = queue.OrderBy(n => n.Distance).First();

                Node newNode = new Node(node.X, node.Y, node.Distance);

                queue.Remove(node);

                if (newNode.Visited) continue;

                newNode.Visited = true;

                if (newNode.X == endPos[0] && newNode.Y == endPos[1]) {

                    AdventOfCode.PrintWithColor(newNode.Distance.ToString());
                    break;

                }

                foreach (var neighbor in newNode.Neighbors(new List<Node>())) {

                    neighbor.Distance++;

                    queue.Add(neighbor);

                }

            }

            Console.WriteLine(startPos[0] + " " + startPos[1]);
            Console.WriteLine(endPos[0] + " " + endPos[1]);

            Console.ReadKey();

        }

        class Node {

            public int X { get; set; }
            public int Y { get; set; }
            public int Distance { get; set; }
            public int Height { get; set; }
            public bool Visited { get; set; }

            private Node() {

                Height = GetHeight();
                Visited = false;

            }

            public Node(int x, int y) : this() {

                X = x;
                Y = y;

            }

            public Node(int x, int y, int distance) : this() {

                X = x;
                Y = y;
                
                Distance = distance;

            }

            public Node(int x, int y, int distance, bool visited) : this() {

                X = x;
                Y = y;
                
                Distance = distance;
                Visited = visited;

            }

            private int GetHeight() {

                char character = AdventOfCode.GetInput(path: "demo.txt")[X][Y];

                if (character == 'S') {

                    return 0;

                } else if (character == 'E') {
                    
                    return 25;

                } else {

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
