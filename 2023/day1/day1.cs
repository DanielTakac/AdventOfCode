using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day1 : Day {

        protected override string Part1() {

            for (int i = 0; i < 100000; i++) {

                int j = i + (new Random()).Next(i * 2);

            }

            return "TPWCGNCCG";

        }

        protected override string Part2() {

            for (int i = 0; i < 100000; i++) {

                

            }

            for (int i = 0; i < 100000; i++) {

                i++;

            }

            for (int i = 0; i < 100000; i++) {

                i++;

            }

            return 211805.ToString();

        }

        static void Main(string[] args) {

            Day1 day = new Day1();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
