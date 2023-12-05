using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day5 : Day {

        protected override string Part1() {

            string[] input = AdventOfCode.GetInput("input.txt");

            List<LookupTable> lookUpTables = new List<LookupTable>();

            string[] conversionTypes = { "seed-to-soil", "soil-to-fertilizer", "fertilizer-to-water", "water-to-light", "light-to-temperature", "temperature-to-humidity", "humidity-to-location" };

            foreach (string type in conversionTypes) {

                lookUpTables.Add(new LookupTable(type));

            }

            foreach (LookupTable lookupTable in lookUpTables) {

                List<int[]> map = GetMap(input, lookupTable.conversionType);

                List<int> destRanges = new List<int>();
                List<int> sourceRanges = new List<int>();
                List<int> rangeLengths = new List<int>();

                foreach (int[] ranges in map) {

                    destRanges.Add(ranges[0]);
                    sourceRanges.Add(ranges[1]);
                    rangeLengths.Add(ranges[2]);

                }

                lookupTable.destRanges = destRanges;
                lookupTable.sourceRanges = sourceRanges;
                lookupTable.rangeLengths = rangeLengths;

            }

            int[] seeds = GetSeeds(input);

            List<int> locations = new List<int>();

            foreach (int seed in seeds) {

                int convertedSeed = seed;

                AdventOfCode.PrintWithColor("Seed: " + seed, ConsoleColor.Yellow);

                foreach (LookupTable table in lookUpTables) {

                    Console.WriteLine(table.conversionType);
                    Console.WriteLine("Converted Seed: " + convertedSeed);

                    for (int i = 0; i < table.sourceRanges.Count; i++) {

                        if (convertedSeed >= table.sourceRanges[i] && convertedSeed < table.sourceRanges[i] + table.rangeLengths[i]) {

                            Console.WriteLine($"Seed {convertedSeed} is between source range {table.sourceRanges[i]} and {table.sourceRanges[i] + table.rangeLengths[i]}");
                            Console.WriteLine($"{convertedSeed} -> {convertedSeed + table.destRanges[i] - table.sourceRanges[i]}");

                            convertedSeed += table.destRanges[i] - table.sourceRanges[i];

                            break;

                        }

                    }

                    Console.WriteLine();

                }

                locations.Add(convertedSeed);

            }

            int lowestLocation = locations[0];

            foreach (int location in locations) {

                if (location < lowestLocation) {

                    lowestLocation = location;

                }

            }

            return lowestLocation.ToString();

        }

        class LookupTable {

            public string conversionType {  get; set; }
            public List<int> sourceRanges { get; set; }
            public List<int> destRanges { get; set; }
            public List<int> rangeLengths { get; set; }

            public LookupTable(string conversionType) {

                this.conversionType = conversionType;
                sourceRanges = new List<int>();
                destRanges = new List<int>();
                rangeLengths = new List<int>();

            }

        }

        private int[] GetSeeds(string[] input) {

            int[] seeds = input[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x.Trim())).ToArray();

            Console.Write("Seeds: ");

            foreach (int seed in seeds) {

                Console.Write(seed + " ");

            }

            Console.WriteLine();

            return seeds;

        }

        private List<int[]> GetMap(string[] input, string mapType) {

            List<int[]> map = new List<int[]>();

            for (int i = 0; i < input.Length; i++) {

                if (input[i] == mapType + " map:") {

                    for (int j = i + 1; j < input.Length; j++) {

                        if (input[j].Length == 0) {

                            break;

                        }

                        int[] values = input[j].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                        map.Add(values);

                    }

                }

            }

            return map;

        }

        protected override string Part2() {

            return string.Empty;

        }

        static void Main(string[] args) {

            var day = new Day5();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
