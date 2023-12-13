using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day12 : Day {

        protected override string Part1() {

            string[] input = AdventOfCode.GetInput();

            int totalPossibilities = 0;

            foreach (string line in input) {

                totalPossibilities += GetPossibleArrangements(line).Count;

            }

            return totalPossibilities.ToString();

        }

        private static string UnfoldRecord(string record) {

            string unfoldedStr = string.Empty;
            string unfoldedSizes = string.Empty;

            for (int i = 0; i < 5; i++) {

                unfoldedStr += record.Split()[0];
                unfoldedSizes += record.Split()[1];

            }

            return unfoldedStr + " " + unfoldedSizes;

        }

        private static void PrintArrangement(string str) {

            foreach (char ch in str) {

                if (ch == '#') {
                    AdventOfCode.PrintWithColor(ch, ConsoleColor.Cyan, false);
                } else if (ch == '?') {
                    AdventOfCode.PrintWithColor(ch, ConsoleColor.Red, false);
                } else {
                    Console.Write(ch);
                }

            }

            Console.WriteLine();

        }

        private static List<string> GetPossibleArrangements(string input) {

            string str = input.Split()[0];
            int[] sizes = input.Split()[1].Split(',').Select(int.Parse).ToArray();

            bool[] lockedPositions = new bool[str.Length];

            for (int i = 0; i < str.Length; i++) {

                if (str[i] != '?') {

                    lockedPositions[i] = true;

                } else {

                    lockedPositions[i] = false;

                }

            }

            List<string> possibleStrs = [];

            GenerateVariations(str.ToCharArray(), lockedPositions, 0, str.Length, sizes, ref possibleStrs);

            return possibleStrs;

        }

        static void GenerateVariations(char[] variation, bool[] lockedPositions, int index, int length, int[] sizes, ref List<string> possibleStrs) {
            if (index == length) {
                if (IsValid(string.Join("", variation), sizes)) {
                    possibleStrs.Add(string.Join("", variation));
                }
                return;
            }

            if (lockedPositions[index]) {

                GenerateVariations(variation, lockedPositions, index + 1, length, sizes, ref possibleStrs);

            } else {

                variation[index] = '.';
                GenerateVariations(variation, lockedPositions, index + 1, length, sizes, ref possibleStrs);

                variation[index] = '#';
                GenerateVariations(variation, lockedPositions, index + 1, length, sizes, ref possibleStrs);

            }

        }

        private static bool IsValid(string str, int[] sizes) {

            Regex regex = new Regex("#+");

            MatchCollection matches = regex.Matches(str);

            if (matches.Count != sizes.Length) return false;

            for (int i = 0; i < matches.Count; i++) {

                if (matches[i].Length != sizes[i]) {

                    return false;

                }

            }

            return true;

        }

        protected override string Part2() {

            string[] input = AdventOfCode.GetInput();

            int totalPossibilities = 0;

            foreach (string line in input) {

                totalPossibilities += GetPossibleArrangements(UnfoldRecord(line)).Count;

            }

            return totalPossibilities.ToString();

        }

        static void Main(string[] args) {

            var day = new Day12();

            day.Solve(true);

            Console.ReadKey(true);

        }

    }

}
