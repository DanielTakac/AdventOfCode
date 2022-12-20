using day18;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode {

    class Day13 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput();

            List<Cube> cubes = new List<Cube>();

            foreach (string line in input) {

                int[] position = Array.ConvertAll(line.Split(","), x => int.Parse(x));

                Cube cube = new Cube(position);

                cubes.Add(cube);

            }
            
            for (int i = 0; i < cubes.Count; i++) {

                cubes[i].CheckSides(cubes);

            }

            int notTouchingSides = 0;

            foreach (Cube cube in cubes) {

                notTouchingSides += cube.NotTouchingSides();

            }

            AdventOfCode.PrintWithColor($"Part 1: {notTouchingSides}", ConsoleColor.Green);

            Console.ReadKey();

        }

    }

}
