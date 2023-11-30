using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day1 : Day {

        protected override string Part1() {

            return "TPWCGNCCG";

        }

        protected override string Part2() {

            return 211805.ToString();

        }

        static void Main(string[] args) {

            Day1 day = new Day1();

            day.Solve();

            Console.ReadKey();

        }

    }

}
