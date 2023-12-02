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

        protected void Solve(bool liveTableUpdates = false) {

            Stopwatch sw = new Stopwatch();

            string part1 = string.Empty;
            string part2 = string.Empty;

            if (!liveTableUpdates) {

                // Part 1

                sw.Start();
                part1 = Part1();
                sw.Stop();

                // Part 2

                sw.Restart();
                part2 = Part2();
                sw.Stop();

            }

            var table = new Table();

            AnsiConsole.Live(table)
            .Start(ctx => {

                table.AddColumn(new TableColumn("Part").Centered());
                table.AddColumn(new TableColumn("Solution").Centered());
                table.AddColumn(new TableColumn("Elapsed Time").Centered());
                ctx.Refresh();

                if (liveTableUpdates) {

                    // Part 1

                    sw.Start();
                    part1 = Part1();
                    sw.Stop();

                }

                long part1Time = sw.ElapsedMilliseconds;

                string part1TimeStr = part1Time < 1000 ? $"{part1Time}ms" : $"{part1Time / 1000.0}s";

                string coloredPart1TimeStr = $"[bold {GetColorFromTime(part1Time)}]{part1TimeStr}[/]";

                table.AddRow("Part 1", part1, coloredPart1TimeStr);
                ctx.Refresh();

                if (liveTableUpdates) {

                    // Part 2

                    sw.Restart();
                    part2 = Part2();
                    sw.Stop();

                }

                long part2Time = sw.ElapsedMilliseconds;

                string part2TimeStr = part2Time < 1000 ? $"{part2Time}ms" : $"{part2Time / 1000.0}s";

                string coloredPart2TimeStr = $"[bold {GetColorFromTime(part2Time)}]{part2TimeStr}[/]";

                table.AddRow("Part 2", part2, coloredPart2TimeStr);
                ctx.Refresh();

                /*table.AddRow("#1", $"[bold {GetColorFromTime(0)}]{0}ms[/]");
                table.AddRow("#2", $"[bold {GetColorFromTime(1)}]{1}ms[/]");
                table.AddRow("#3", $"[bold {GetColorFromTime(5)}]{5}ms[/]");
                table.AddRow("#4", $"[bold {GetColorFromTime(10)}]{10}ms[/]");
                table.AddRow("#5", $"[bold {GetColorFromTime(25)}]{25}ms[/]");
                table.AddRow("#6", $"[bold {GetColorFromTime(50)}]{50}ms[/]");
                table.AddRow("#7", $"[bold {GetColorFromTime(100)}]{100}ms[/]");
                table.AddRow("#8", $"[bold {GetColorFromTime(250)}]{250}ms[/]");
                table.AddRow("#9", $"[bold {GetColorFromTime(500)}]{500}ms[/]");
                table.AddRow("#10", $"[bold {GetColorFromTime(750)}]{750}ms[/]");
                table.AddRow("#11", $"[bold {GetColorFromTime(1000)}]{1}s[/]");
                table.AddRow("#12", $"[bold {GetColorFromTime(2000)}]{2}s[/]");
                table.AddRow("#13", $"[bold {GetColorFromTime(3000)}]{3}s[/]");
                table.AddRow("#14", $"[bold {GetColorFromTime(4000)}]{4}s[/]");
                table.AddRow("#15", $"[bold {GetColorFromTime(5000)}]{5}s[/]");
                table.AddRow("#16", $"[bold {GetColorFromTime(10000)}]{10}s[/]");
                table.AddRow("#17", $"[bold {GetColorFromTime(20000)}]{20}s[/]");
                table.AddRow("#18", $"[bold {GetColorFromTime(30000)}]{30}s[/]");
                table.AddRow("#19", $"[bold {GetColorFromTime(40000)}]{40}s[/]");*/

            });

        }

        private string GetColorFromTime(long time) {

            string[] colors = new string[] { "darkmagenta_1", "purple_1", "royalblue1", "cornflowerblue", "steelblue1", "darkslategray2", "seagreen1_1", "seagreen1", "seagreen2", "springgreen2_1", "green1", "greenyellow", "yellow1", "gold1", "gold3_1", "orange3", "darkorange3_1", "orangered1", "red1" };

            if (time < 1) {
                return colors[0];
            } else if (time < 5) {
                return colors[1];
            } else if (time < 10) {
                return colors[2];
            } else if (time < 25) {
                return colors[3];
            } else if (time < 50) {
                return colors[4];
            } else if (time < 100) {
                return colors[5];
            } else if (time < 250) {
                return colors[6];
            } else if (time < 500) {
                return colors[7];
            } else if (time < 750) {
                return colors[8];
            } else if (time < 1000) {
                return colors[9];
            } else if (time < 2000) {
                return colors[10];
            } else if (time < 3000) {
                return colors[11];
            } else if (time < 4000) {
                return colors[12];
            } else if (time < 5000) {
                return colors[13];
            } else if (time < 10000) {
                return colors[14];
            } else if (time < 20000) {
                return colors[15];
            } else if (time < 30000) {
                return colors[16];
            } else if (time < 40000) {
                return colors[17];
            } else {
                return colors[18];
            }

        }

    }

}
