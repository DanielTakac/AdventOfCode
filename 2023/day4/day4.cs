using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day4 : Day {

        protected override string Part1() {

            string[] lines = AdventOfCode.GetInput("example.txt");

            GetWinningNumbers(lines[0]);

            return string.Empty;

        }

        private List<int> GetWinningNumbers(string card) {

            string numsStr = card.Split('|')[1].Trim();

            int[] nums = numsStr.Split(' ').Where(s => s != "").Select(int.Parse).ToArray();

            foreach (int num in nums) {

                Console.Write("'" + num + "' ");

            }

            Console.WriteLine();

            return null;

        }

        private List<int> GetMyNumbers(string card) {

            return null;

        }

        protected override string Part2() {

            return string.Empty;

        }

        static void Main(string[] args) {

            var day = new Day4();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
