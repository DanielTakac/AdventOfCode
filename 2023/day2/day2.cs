using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day2 : Day {

        protected override string Part1() {

            string[] input = AdventOfCode.GetInput("test-input.txt");

            foreach (string str in input) {

                Console.WriteLine(str);

            }

            System.Threading.Thread.Sleep(500);

            return string.Empty;

        }

        protected override string Part2() {

            System.Threading.Thread.Sleep(500);

            return string.Empty;

        }

        static void Main(string[] args) {

            var day = new Day2();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
