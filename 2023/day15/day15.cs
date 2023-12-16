using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day15 : Day {

        protected override string Part1() {

            // --- One liner ---
            return AdventOfCode.GetInput()[0].Split(',').Select(x => x.Aggregate(0, (y,z) => (y+z)*17%256)).Sum().ToString();

        }

        private static int HASH(string input) {

            int currentValue = 0;

            foreach (int ch in input) {

                currentValue += ch;
                currentValue *= 17;
                currentValue %= 256;

            }

            return currentValue;

        }

        public struct Lens {

            public string Label { get; }
            public int FocalLength { get; }

            public Lens(string label, int focalLength) {

                Label = label;
                FocalLength = focalLength;

            }

            public override string ToString() {

                return $"[{Label} {FocalLength}]";

            }

        }

        protected override string Part2() {

            string input = AdventOfCode.GetInput()[0];

            string[] steps = input.Split(",");

            List<Lens>[] boxes = new List<Lens>[256];

            for (int i = 0; i < boxes.Length; i++) {

                boxes[i] = new List<Lens>();

            }

            Regex labelRegex = new Regex("[a-z]+");
            Regex operationRegex = new Regex("-|=");

            foreach (string step in steps) {

                string label = labelRegex.Match(step).Value;

                char operation = operationRegex.Match(step).Value[0];

                int boxID = HASH(label);

                List<Lens> box = boxes[boxID];

                if (operation == '-') {

                    if (box.Any(lens => lens.Label == label)) {

                        Lens matchingLens = box.Find(lens => lens.Label == label);

                        box.Remove(matchingLens);

                    }

                } else if (operation == '=') {

                    int focalLength = int.Parse(step.Split('=')[1]);

                    Lens newLens = new Lens(label, focalLength);

                    if (box.Count != 0 && box.Any(lens => lens.Label == label)) {

                        int lensIndex = box.FindIndex(lens => lens.Label == label);

                        box[lensIndex] = newLens;

                    } else {

                        box.Add(newLens);

                    }

                }

            }

            int totalFocusingPower = 0;

            for (int i = 0; i < boxes.Length; i++) {

                for (int j = 0; j < boxes[i].Count; j++) {

                    int focusingPower = (i + 1) * (j + 1) * boxes[i][j].FocalLength;

                    totalFocusingPower += focusingPower;

                }

            }

            return totalFocusingPower.ToString();

        }

        static void Main(string[] args) {

            var day = new Day15();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
