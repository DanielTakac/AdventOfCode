using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    public abstract class Day {

        protected abstract string Part1();
        protected abstract string Part2();

        protected void Solve() {

            Console.WriteLine($"Part 1 - {Part1()}");
            Console.WriteLine($"Part 2 - {Part2()}");

            // Use spectre console live table

            // Measure runtime in ms

        }

    }

}
