using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day5 : Day {

        protected override string Part1() {

            string[] input = AdventOfCode.GetInput();

            if (input == null || input.Length == 0 ) return string.Empty;

            List<LookupTable> lookUpTables = new List<LookupTable>();

            string[] conversionTypes = { "seed-to-soil", "soil-to-fertilizer", "fertilizer-to-water", "water-to-light", "light-to-temperature", "temperature-to-humidity", "humidity-to-location" };

            foreach (string type in conversionTypes) {

                lookUpTables.Add(new LookupTable(type));

            }

            foreach (LookupTable lookupTable in lookUpTables) {

                List<long[]> map = GetMap(input, lookupTable.conversionType);

                List<long> destRanges = new List<long>();
                List<long> sourceRanges = new List<long>();
                List<long> rangeLengths = new List<long>();

                foreach (long[] ranges in map) {

                    destRanges.Add(ranges[0]);
                    sourceRanges.Add(ranges[1]);
                    rangeLengths.Add(ranges[2]);

                }

                lookupTable.destRanges = destRanges;
                lookupTable.sourceRanges = sourceRanges;
                lookupTable.rangeLengths = rangeLengths;

            }

            long[] seeds = GetSeeds(input);

            List<long> locations = new List<long>();

            foreach (long seed in seeds) {

                long convertedSeed = seed;

                foreach (LookupTable table in lookUpTables) {

                    for (int i = 0; i < table.sourceRanges.Count; i++) {

                        if (convertedSeed >= table.sourceRanges[i] && convertedSeed < table.sourceRanges[i] + table.rangeLengths[i]) {

                            convertedSeed += table.destRanges[i] - table.sourceRanges[i];
                            break;

                        }

                    }

                    Console.WriteLine();

                }

                locations.Add(convertedSeed);

            }

            long lowestLocation = locations[0];

            foreach (long location in locations) {

                if (location < lowestLocation) {

                    lowestLocation = location;

                }

            }

            return lowestLocation.ToString();

        }

        class LookupTable {

            public string conversionType {  get; set; }
            public List<long> sourceRanges { get; set; }
            public List<long> destRanges { get; set; }
            public List<long> rangeLengths { get; set; }

            public LookupTable(string conversionType) {

                this.conversionType = conversionType;
                sourceRanges = new List<long>();
                destRanges = new List<long>();
                rangeLengths = new List<long>();

            }

        }

        private long[] GetSeeds(string[] input) {

            long[] seeds = input[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x.Trim())).ToArray();

            Console.Write("Seeds: ");

            foreach (long seed in seeds) {

                Console.Write(seed + " ");

            }

            Console.WriteLine();

            return seeds;

        }

        private List<long[]> GetMap(string[] input, string mapType) {

            List<long[]> map = new List<long[]>();

            for (int i = 0; i < input.Length; i++) {

                if (input[i] == mapType + " map:") {

                    for (int j = i + 1; j < input.Length; j++) {

                        if (input[j].Length == 0) {

                            break;

                        }

                        long[] values = input[j].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

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
