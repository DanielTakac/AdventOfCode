using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day2 : Day {

        protected override string Part1() {

            string[] input = AdventOfCode.GetInput("input.txt");

            int sumOfIds = 0;

            for (int i = 0; i < input.Length; i++) {

                List<Dictionary<string, int>> listOfCubes = GetAmountOfCubes(input[i]);

                bool isPossible = true;

                foreach (Dictionary<string,int> cube in listOfCubes) {

                    /*if (cube["red"] <= 12) {
                        AdventOfCode.PrintWithColor($"{cube["red"]} <= 12", ConsoleColor.Green);
                    } else {
                        AdventOfCode.PrintWithColor($"{cube["red"]} > 12", ConsoleColor.Red);
                    }

                    if (cube["green"] <= 13) {
                        AdventOfCode.PrintWithColor($"{cube["green"]} <= 13", ConsoleColor.Green);
                    } else {
                        AdventOfCode.PrintWithColor($"{cube["green"]} > 13", ConsoleColor.Red);
                    }

                    if (cube["blue"] <= 14) {
                        AdventOfCode.PrintWithColor($"{cube["blue"]} <= 13", ConsoleColor.Green);
                    } else {
                        AdventOfCode.PrintWithColor($"{cube["blue"]} > 13", ConsoleColor.Red);
                    }*/

                    if (cube["red"] > 12 || cube["green"] > 13 || cube["blue"] > 14) {

                        isPossible = false;

                    }

                }

                if (isPossible) {

                    sumOfIds += i + 1;

                }

            }

            return sumOfIds.ToString();

        }

        private List<Dictionary<string, int>> GetAmountOfCubes(string input) {

            List<Dictionary<string, int>> listOfCubes = new List<Dictionary<string, int>>();

            // input: Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
            // splitInput: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
            // set: 1 red, 2 green, 6 blue
            // subset: 1 red
            string splitInput = input.Split(':')[1].Trim();

            string[] sets = splitInput.Split(';');

            foreach (string set in sets) {

                Dictionary<string, int> cubes = new Dictionary<string, int> {
                    { "red", 0 },
                    { "green", 0 },
                    { "blue", 0 }
                };

                string[] subsets = set.Split(',');

                foreach (string subset in subsets) {

                    string[] cube = subset.Trim().Split(' ');

                    cubes[cube[1]] = int.Parse(cube[0]);

                }

                listOfCubes.Add(cubes);

            }

            return listOfCubes;

        }

        protected override string Part2() {

            string[] input = AdventOfCode.GetInput("input.txt");

            int sumOfPowers = 0;

            for (int i = 0; i < input.Length; i++) {

                List<Dictionary<string, int>> listOfCubes = GetAmountOfCubes(input[i]);

                Dictionary<string, int> fewestCubesPossible = new Dictionary<string, int> {
                    { "red", 0 },
                    { "green", 0 },
                    { "blue", 0 }
                };

                foreach (Dictionary<string, int> cube in listOfCubes) {

                    foreach (KeyValuePair<string, int> colorOfCube in cube) {

                        if (colorOfCube.Value > fewestCubesPossible[colorOfCube.Key]) {

                            fewestCubesPossible[colorOfCube.Key] = colorOfCube.Value;

                        }

                    }

                }

                int power = fewestCubesPossible["red"] * fewestCubesPossible["green"] * fewestCubesPossible["blue"];

                sumOfPowers += power;

            }

            return sumOfPowers.ToString();

        }

        static void Main(string[] args) {

            var day = new Day2();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
