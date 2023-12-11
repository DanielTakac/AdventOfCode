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

                // Loop until the last sequence is all zeroes
                while (sequences.Last().Where(num => num != 0).Count() != 0) {

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

                sumOfPredictedValues += sequences[0].Last();

            }

            return sumOfPredictedValues.ToString();

        }

        protected override string Part2() {

            string[] input = AdventOfCode.GetInput();

            int sumOfPredictedValues = 0;

            foreach (string line in input) {

                List<List<int>> sequences = [line.Split().Select(int.Parse).ToList()];

                // Loop until the last sequence is all zeroes
                while (sequences.Last().Where(num => num != 0).Count() != 0) {

                    List<int> lastSeq = sequences.Last();
                    List<int> newSeq = [];

                    for (int i = 0; i < lastSeq.Count - 1; i++) {

                        int diff = lastSeq[i + 1] - lastSeq[i];

                        newSeq.Add(diff);

                    }

                    sequences.Add(newSeq);

                }

                sequences.Last().Insert(0, 0);

                for (int i = sequences.Count - 2; i >= 0; i--) {

                    int diff = sequences[i].First() - sequences[i + 1].First();

                    sequences[i].Insert(0, diff);

                }

                sumOfPredictedValues += sequences[0].First();

            }

            return sumOfPredictedValues.ToString();

        }

        static void Main(string[] args) {

            var day = new Day9();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
