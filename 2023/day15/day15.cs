using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day15 : Day {

        protected override string Part1() {

            // --- One liner ---
            return AdventOfCode.GetInput()[0].Split(',').Select(x => x.Aggregate(0, (y,z) => (y+z)*17%256)).Sum().ToString();

        }

        private static int HASH(string input) {

            int currentValue = 0;

            foreach (int ch in input) {

                currentValue += ch;
                currentValue *= 17;
                currentValue %= 256;

            }

            return currentValue;

        }

        protected override string Part2() {

            return string.Empty;

        }

        static void Main(string[] args) {

            var day = new Day15();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
