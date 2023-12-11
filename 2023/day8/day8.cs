using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day8 : Day {

        protected override string Part1() {

            string[] input = AdventOfCode.GetInput("input.txt");

            Dictionary<string, string[]> nodes = [];

            string instructions = input[0];

            Regex nodeRegex = new Regex("[A-Z]{3}");

            for (int i = 2; i < input.Length; i++) {

                MatchCollection matches = nodeRegex.Matches(input[i]);

                nodes.Add(matches[0].Value, [matches[1].Value, matches[2].Value]);

            }

            string currentNode = "AAA";
            int steps = 0;

            for (int i = 0; i < instructions.Length; i++) {

                steps++;

                currentNode = (instructions[i] == 'L') ? nodes[currentNode][0] : nodes[currentNode][1];

                if (i == instructions.Length - 1) {

                    i = -1;

                }

                if (currentNode == "ZZZ") break;

            }

            return steps.ToString();

        }

        protected override string Part2() {

            string[] input = AdventOfCode.GetInput("input.txt");

            Dictionary<string, string[]> nodes = [];

            string instructions = input[0];

            Regex nodeRegex = new Regex("[A-Z0-9]{3}");

            for (int i = 2; i < input.Length; i++) {

                MatchCollection matches = nodeRegex.Matches(input[i]);

                nodes.Add(matches[0].Value, [matches[1].Value, matches[2].Value]);

            }

            string[] currentNodes = nodes.Where(x => x.Key[2] == 'A').Select(x => x.Key).ToArray();
            currentNodes = [nodes.Where(x => x.Key[2] == 'A').Select(x => x.Key).ToArray()[0]];
            int steps = 0;

            for (int i = 0; i < instructions.Length; i++) {

                Console.Write($"{i} - {instructions[i]} - ");

                foreach (string node in currentNodes) {

                    Console.Write(node + " ");

                }

                Console.WriteLine();

                // Thread.Sleep(50);

                for (int j = 0; j < currentNodes.Length; j++) {

                    currentNodes[j] = (instructions[i] == 'L') ? nodes[currentNodes[j]][0] : nodes[currentNodes[j]][1];

                }

                steps++;

                if (i == instructions.Length - 1) {

                    i = -1;

                }

                // if all nodes end with Z
                if (currentNodes.Count(x => x[2] == 'Z') == currentNodes.Count()) {

                    break;

                }

            }

            return steps.ToString();

        }

        static void Main(string[] args) {

            var day = new Day8();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
