using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Spectre.Console;

namespace AdventOfCode {

    public abstract class Day {

        protected abstract string Part1();
        protected abstract string Part2();

        protected void Solve() {

            var table = new Table();

            // table.AddColumn(new TableColumn("Part").Centered());
            // table.AddColumn(new TableColumn("Solution").Centered());
            // table.AddColumn(new TableColumn("Elapsed time").Centered());

            AnsiConsole.Live(table)
            .Start(ctx => {
                table.AddColumn(new TableColumn("Part").Centered());
                ctx.Refresh();
                Thread.Sleep(1000);

                table.AddColumn(new TableColumn("Solution").Centered());
                ctx.Refresh();
                Thread.Sleep(1000);

                // to-do: put all the code in here

            });

            Stopwatch sw = new Stopwatch();

            sw.Start();
            string part1 = Part1();
            sw.Stop();

            long part1Time = sw.ElapsedMilliseconds;

            table.AddRow("Part 1", part1, part1Time.ToString());

            sw.Restart();
            string part2 = Part2();
            sw.Stop();

            long part2Time = sw.ElapsedMilliseconds;

            table.AddRow("Part 2", part2, part2Time.ToString());

        }

    }

}
