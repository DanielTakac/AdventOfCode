using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day1 : Day {

        protected override string Part1() {

            string[] input = AdventOfCode.GetInput("input.txt");

            List<int> nums = new List<int>();

            foreach (string line in input) {

                List<int> digits = GetDigitsFromString(line);

                int num = MakeNumberFromDigits(digits);

                nums.Add(num);

            }

            int sum = 0;

            foreach (int num in nums) {

                sum += num;

            }

            return sum.ToString();

        }

        // Part 1
        private List<int> GetDigitsFromString(string input) {

            List<int> digits = new List<int>();

            for (int i = 0; i < input.Length; i++) {

                if (Char.IsNumber(input[i])) {

                    int digit = int.Parse(input[i].ToString());

                    digits.Add(digit);

                }

            }

            if (digits.Count == 0) {
                AdventOfCode.PrintWithColor($"Error: no digits found in {input}", ConsoleColor.Red);
            }

            return digits;

        }

        // Part 2
        private List<int> GetDigitsAndSpelledDigitsFromString(string input) {

            List<int> digitsList = new List<int>();

            Dictionary<int, int> digitsDict = new Dictionary<int, int>();

            // Normal digits
            for (int i = 0; i < input.Length; i++) {

                if (Char.IsNumber(input[i])) {

                    int digit = int.Parse(input[i].ToString());

                    digitsDict.Add(i, digit);

                }

            }

            // Spelled out digits
            Dictionary<string, int> wordDigits = new Dictionary<string, int> {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 }
            };

            foreach (KeyValuePair<string, int> word in wordDigits) {

                int index = input.IndexOf(word.Key);

                while (index != -1) {

                    digitsDict.Add(index, word.Value);
                    index = input.IndexOf(word.Key, index + 1);

                }

            }

            // Order the digits dictionary
            digitsDict = digitsDict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            // Add the digits to the list
            foreach (KeyValuePair<int, int> digit in digitsDict) {

                digitsList.Add(digit.Value);

            }   

            if (digitsList.Count == 0) {
                AdventOfCode.PrintWithColor($"Error: no digits found in {input}", ConsoleColor.Red);
            }

            return digitsList;

        }

        private int MakeNumberFromDigits(List<int> digits) {

            string numAsString = digits[0].ToString() + digits.Last();

            return int.Parse(numAsString);

        }

        protected override string Part2() {

            string[] input = AdventOfCode.GetInput("input.txt");

            List<int> nums = new List<int>();

            foreach (string line in input) {

                List<int> digits = GetDigitsAndSpelledDigitsFromString(line);

                int num = MakeNumberFromDigits(digits);

                nums.Add(num);

            }

            int sum = 0;

            foreach (int num in nums) {

                sum += num;

            }

            return sum.ToString();

        }

        static void Main(string[] args) {

            Day1 day = new Day1();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
