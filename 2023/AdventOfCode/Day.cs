using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AdventOfCode {

    public abstract class Day {

        protected abstract string Part1();
        protected abstract string Part2();

        protected void Solve() {

            Stopwatch sw = new Stopwatch();

            sw.Start();
            string part1 = Part1();
            sw.Stop();

            long part1Time = sw.ElapsedMilliseconds;

            Console.WriteLine($"Part 1 - {part1} - {part1Time}ms");

            sw.Restart();
            string part2 = Part2();
            sw.Stop();

            long part2Time = sw.ElapsedMilliseconds;

            Console.WriteLine($"Part 2 - {part2} - {part2Time}ms");

            // Use spectre console live table

        }

    }

}
