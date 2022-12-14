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

            int[,] distances = new int[input.Length, input[0].Length];

            for (int x = 0; x < input.Length; x++) {

                for (int y = 0; y < input[x].Length; y++) {

                    distances[x, y] = int.MaxValue;

                }

            }

            distances[startPos[0], startPos[1]] = 0;

            int[] FindSmallestDistance() {

                int[] smallestDistance = new int[2];

                for (int x = 0; x < input.Length; x++) {

                    for (int y = 0; y < input[x].Length; y++) {

                        if (distances[x, y] < distances[smallestDistance[0], smallestDistance[1]]) {

                            smallestDistance[0] = x;
                            smallestDistance[1] = y;

                        }

                    }

                }

                return smallestDistance;

            }

            Node FindNodeWithSmallestDistance(List<Node> nodes) {

                Node smallestDistanceNode = nodes[0];

                int[] positionOfSmallestNode = FindSmallestDistance();

                foreach (Node node in nodes) {

                    if (node.X == positionOfSmallestNode[0] && node.Y == positionOfSmallestNode[1]) {

                        smallestDistanceNode = node;

                    }

                }

                return smallestDistanceNode;

            }

            var queue = new List<Node>() { new Node(0, 0, 0) };

            var test = new NodeTest();

            // test.Test();

            int counter = 0;

            while (true) {

                foreach (Node coolNode in queue) AdventOfCode.PrintWithColor(coolNode.X + ", " + coolNode.Y + ", " + coolNode.Distance + ", " + coolNode.Height + ", " + IsVisited(coolNode), ConsoleColor.Red);

                Node node = FindNodeWithSmallestDistance(queue);

                Node newNode = new Node(node.X, node.Y, distances[node.X, node.Y]);

                queue.Remove(node);

                if (IsVisited(newNode)) continue;

                visitedNodes.Add(new int[] { newNode.X, newNode.Y }, true);

                if (newNode.X == endPos[0] && newNode.Y == endPos[1]) {

                    AdventOfCode.PrintWithColor(newNode.Distance.ToString());
                    break;

                }

                foreach (var neighbor in newNode.Neighbors(new List<Node>(), ref counter)) {

                    neighbor.Distance++;

                    queue.Add(neighbor);

                    AdventOfCode.PrintWithColor(neighbor.X + ", " + neighbor.Y + ", " + neighbor.Distance + ", " + neighbor.Height + ", " + IsVisited(neighbor), ConsoleColor.Yellow); 

                }

            }

            Console.ReadKey();

        }

    }

}
