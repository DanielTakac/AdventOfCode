using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {
    
    class NodeTest {

        public void Test() {

            var visitedNodes = new Dictionary<int[], bool>();

            bool IsVisited(Node node) {

                foreach (KeyValuePair<int[], bool> visitedNode in visitedNodes) {

                    if (visitedNode.Key[0] == node.X && visitedNode.Key[1] == node.Y) {

                        return true;

                    }

                }

                return false;

            }

            Console.WriteLine("\n");

            var node = new Node(1, 4, 19);

            var queue = new List<Node>() { node };

            foreach (Node coolNode in queue) {

                AdventOfCode.PrintWithColor(coolNode.X + ", " + coolNode.Y + ", " + coolNode.Distance + ", " + coolNode.Height + ", " + IsVisited(coolNode), ConsoleColor.Red);

            }

            int counter = 0;

            var neighbors = node.Neighbors(new List<Node>(), ref counter);

            foreach (var neighbor in neighbors) {

                neighbor.Distance++;

                queue.Add(neighbor);

                AdventOfCode.PrintWithColor(neighbor.X + ", " + neighbor.Y + ", " + neighbor.Distance + ", " + neighbor.Height + ", " + IsVisited(neighbor), ConsoleColor.Yellow);

            }

        }
        
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

        public List<Node> Neighbors(List<Node> neighbors, ref int counter) {

            counter++;

            AdventOfCode.PrintWithColor(counter.ToString(), ConsoleColor.Gray);

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
                        neighbors[j].Y == potentialNeighbors[i].Y) {
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

                if (potentialNeighbors[i].Height <= this.Height + 1) {

                    neighbors.Add(potentialNeighbors[i]);

                }

            }

            return neighbors;

        }

    }

}
