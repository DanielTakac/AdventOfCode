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

                // ### Debugging ###

                foreach (int digit in digits) {

                    Console.Write(digit + " ");

                }

                Console.Write(" -> " + num + "\n");

                // #################

                nums.Add(num);

            }

            int sum = 0;

            foreach (int num in nums) {

                sum += num;

            }

            AdventOfCode.PrintWithColor(sum);

            return sum.ToString();

        }

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

        private int MakeNumberFromDigits(List<int> digits) {

            string numAsString = digits[0].ToString() + digits.Last();

            return int.Parse(numAsString);

        }

        protected override string Part2() {



            return "";

        }

        static void Main(string[] args) {

            Day1 day = new Day1();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
