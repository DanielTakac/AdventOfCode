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

            return string.Empty;

        }

        static void Main(string[] args) {

            var day = new Day8();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
