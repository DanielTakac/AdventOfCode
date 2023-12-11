using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day8 : Day {

        protected override string Part1() {

            string[] input = AdventOfCode.GetInput();

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

        // Greatest Common Divisor
        static long GCD(long a, long b) {
            while (b != 0) {
                (a, b) = (b, a % b);
            }
            return a;
        }

        // Least Common Multiple
        static long LCM(long a, long b) {
            return (a / GCD(a, b)) * b;
        }

        protected override string Part2() {

            string[] input = AdventOfCode.GetInput();

            Dictionary<string, string[]> nodes = [];

            string instructions = input[0];

            Regex nodeRegex = new Regex("[A-Z0-9]{3}");

            for (int i = 2; i < input.Length; i++) {

                MatchCollection matches = nodeRegex.Matches(input[i]);

                nodes.Add(matches[0].Value, [matches[1].Value, matches[2].Value]);

            }

            string[] currentNodes = nodes.Where(x => x.Key[2] == 'A').Select(x => x.Key).ToArray();
            int[] steps = new int[currentNodes.Length];

            for (int node = 0; node < currentNodes.Length; node++) {

                for (int i = 0; i < instructions.Length; i++) {

                    currentNodes[node] = (instructions[i] == 'L') ? nodes[currentNodes[node]][0] : nodes[currentNodes[node]][1];

                    steps[node]++;

                    if (i == instructions.Length - 1) {

                        i = -1;

                    }

                    if (currentNodes[node][2] == 'Z') break;

                }

            }

            long lcm = 1;

            // LCM of steps
            for (int i = 0; i < steps.Length; i++) {

                lcm = LCM(lcm, steps[i]);

            }

            return lcm.ToString();

        }

        static void Main(string[] args) {

            var day = new Day8();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
