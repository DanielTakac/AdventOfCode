using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day14 : Day {

        protected override string Part1() {

            string[] input = AdventOfCode.GetInput();

            string[] tiltedDish = TiltDish(input);

            int load = GetLoad(tiltedDish);

            return load.ToString();

        }

        private static string[] TiltDish(string[] dish) {

            List<char[]> tiltedDish = dish.Select(x => x.ToCharArray()).ToList();

            bool allInPlace = false;

            while (!allInPlace) {

                allInPlace = true;

                for (int i = 0; i < tiltedDish.Count; i++) {

                    for (int j = 0; j < tiltedDish[i].Length; j++) {

                        if (tiltedDish[i][j] == 'O' && i > 0 && tiltedDish[i - 1][j] == '.') {

                            tiltedDish[i][j] = '.';
                            tiltedDish[i - 1][j] = 'O';

                            allInPlace = false;

                        }

                    }

                }

            }

            return tiltedDish.Select(x => string.Join("", x)).ToArray();

        }

        private static int GetLoad(string[] dish) {

            int totalLoad = 0;

            for (int i = 0; i < dish.Length; i++) {

                int load = 0;

                for (int j = 0; j < dish[i].Length; j++) {


                    if (dish[i][j] == 'O') {

                        load += dish.Length - i;

                    }

                }

                totalLoad += load;

            }

            return totalLoad;

        }

        protected override string Part2() {

            return string.Empty;

        }

        static void Main(string[] args) {

            var day = new Day14();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
