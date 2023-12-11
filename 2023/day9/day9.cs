using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day9 : Day {

        protected override string Part1() {

            string[] input = AdventOfCode.GetInput();

            int sumOfPredictedValues = 0;

            foreach (string line in input) {

                List<List<int>> sequences = [line.Split().Select(int.Parse).ToList()];

                AdventOfCode.PrintWithColor(line);

                // Loop until the last sequence is all zeroes
                while (sequences.Last().Where(num => num != 0).Count() != 0) {

                    // foreach (int num in sequences.Last()) AdventOfCode.PrintWithColor(num + " ", ConsoleColor.Cyan, false);

                    // Console.WriteLine();

                    List<int> lastSeq = sequences.Last();
                    List<int> newSeq = [];

                    for (int i = 0; i < lastSeq.Count - 1; i++) {

                        int diff = lastSeq[i + 1] - lastSeq[i];

                        newSeq.Add(diff);

                    }

                    sequences.Add(newSeq);

                }

                sequences.Last().Add(0);

                for (int i = sequences.Count - 2; i >= 0; i--) {

                    int diff = sequences[i].Last() + sequences[i + 1].Last();

                    sequences[i].Add(diff);

                }

                Console.WriteLine();

                for (int i = 0; i < sequences.Count; i++) {

                    Console.Write(i + ": ");

                    for (int s = 0; s < 2 * i; s++) {

                        Console.Write(" ");

                    }

                    for (int j = 0; j < sequences[i].Count; j++) {

                        AdventOfCode.PrintWithColor(sequences[i][j], ConsoleColor.Cyan, false);

                        if (sequences[i][j].ToString().Length == 1) {
                            Console.Write("   ");
                        } else {
                            Console.Write("  ");
                        }

                    }

                    Console.WriteLine();

                }

                Console.WriteLine();

                Console.WriteLine();

                sumOfPredictedValues += sequences[0].Last();

            }

            Console.WriteLine();

            return sumOfPredictedValues.ToString();

        }

        protected override string Part2() {

            return string.Empty;

        }

        static void Main(string[] args) {

            var day = new Day9();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
