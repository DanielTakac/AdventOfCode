using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day6 : Day {

        protected override string Part1() {

            string[] input = AdventOfCode.GetInput();

            int[] times = GetTimes(input);
            int[] distances = GetDistances(input);

            Race[] races = new Race[times.Length];

            for (int i = 0; i < times.Length; i++) {

                races[i] = new Race(times[i], distances[i]);

            }

            int multipliedWaysToWin = 1;

            foreach (Race race in races) {

                multipliedWaysToWin *= race.GetNumberOfWaysToWin();

            }

            return multipliedWaysToWin.ToString();

        }

        private int[] GetTimes(string[] input) {

            return input[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        }
        private int[] GetDistances(string[] input) {

            return input[1].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        }

        class Race {

            public int Time { get; private set; }
            public int Distance { get; private set; }

            public Race(int time, int distance) {

                Time = time;
                Distance = distance;

            }

            public int GetNumberOfWaysToWin() {

                int numberOfWaysToWin = 0;

                for (int timeHeld = 0; timeHeld <= Time; timeHeld++) {

                    int travelTime = Time - timeHeld;

                    if (timeHeld * travelTime > Distance) {

                        numberOfWaysToWin++;

                    }

                }

                return numberOfWaysToWin;

            }

        }

        protected override string Part2() {

            return string.Empty;

        }

        static void Main(string[] args) {

            var day = new Day6();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
