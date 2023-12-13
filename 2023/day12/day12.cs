using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day12 : Day {

        protected override string Part1() {

            string[] input = AdventOfCode.GetInput("example.txt");

            List<string> possibilities = GetPossibleArrangements(input[0]);

            foreach (string arrangement in possibilities) {

                PrintArrangement(arrangement);

            }

            string testStr = "#.#.###";
            bool valid = IsValid(testStr, [1, 2, 3]);
            Console.Write(testStr + ": ");
            if (valid) {
                AdventOfCode.PrintWithColor(valid, ConsoleColor.Green);
            } else {
                AdventOfCode.PrintWithColor(valid, ConsoleColor.Red);
            }

            return string.Empty;

        }

        private void PrintArrangement(string str) {

            foreach (char ch in str) {

                if (ch == '#') {
                    AdventOfCode.PrintWithColor(ch, ConsoleColor.Cyan, false);
                } else if (ch == '?') {
                    AdventOfCode.PrintWithColor(ch, ConsoleColor.Red, false);
                } else {
                    Console.Write(ch);
                }

                Console.WriteLine();

            }

        }

        private List<string> GetPossibleArrangements(string input) {

            string str = input.Split()[0];
            int[] sizes = input.Split()[1].Split(',').Select(int.Parse).ToArray();

            List<string> arr = [];

            Console.WriteLine("'" + str + "'");

            

            return arr;

        }

        private bool IsValid(string str, int[] sizes) {

            Regex regex = new Regex("#+");

            MatchCollection matches = regex.Matches(str);

            for (int i = 0; i < matches.Count; i++) {

                AdventOfCode.PrintWithColor(matches[i].Value);

            }

            bool valid = matches.Count == sizes.Length;

            AdventOfCode.PrintWithColor("1. check: " + valid, ConsoleColor.Cyan);

            for (int i = 0; i < matches.Count; i++) {

                if (matches[i].Length != sizes[i]) {

                    valid = false;

                }

            }

            AdventOfCode.PrintWithColor("2. check: " + valid, ConsoleColor.Cyan);

            return valid;

        }

        protected override string Part2() {

            return string.Empty;

        }

        static void Main(string[] args) {

            var day = new Day12();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
