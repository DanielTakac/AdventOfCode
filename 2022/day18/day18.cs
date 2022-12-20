using day18;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode {

    class Day13 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput();

            // 1. Go through the input and add the cubes into a list of a class Cube
            // 2. Each cube class will have an array of bool sides

            foreach (string line in input) {

                int[] position = Array.ConvertAll(line.Split(","), x => int.Parse(x));

                Cube cube = new Cube(position);

            }

            Console.ReadKey();

        }

    }

}
