using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day8 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput("test-input.txt");

            List<List<char>> bits = new List<List<char>>();

            bits.Add(new List<char>());
            bits.Add(new List<char>());
            bits.Add(new List<char>());
            bits.Add(new List<char>());
            bits.Add(new List<char>());

            for (int i = 0; i < input.Length; i++) {

                string line = input[i];

                Console.WriteLine(line);

                bits[i].Add(line[i]);

            }

            foreach (var listOfBits in bits) {

                foreach (var bit in listOfBits) {

                    Console.Write(bit);

                }

                Console.WriteLine();

            }

            Console.ReadKey();

        }

    }

}
