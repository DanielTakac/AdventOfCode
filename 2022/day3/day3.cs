using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1 {

    class Day1 {

        static void Main(string[] args) {

            string path = @"input.txt";

            string[] readText = File.ReadAllLines(path);

            List<char> firstCompartment = new List<char>();
            List<char> secondCompartment = new List<char>();

            foreach (string line in readText) {

                for (int i = 0; i < line.Count(); i++) {

                    if (i < line.Count() / 2) {

                        firstCompartment.Add(line[i]);

                    } else {

                        secondCompartment.Add(line[i]);

                    }

                }

                Console.WriteLine("First compartment: " + firstCompartment.Count());
                Console.WriteLine("Second compartment: " + secondCompartment.Count());

                Console.WriteLine("First compartment: ");

                for (int i = 0; i < firstCompartment.Count; i++) {

                    Console.Write(firstCompartment[i] + " - ");

                }

                Console.WriteLine("\nSecond compartment: ");

                for (int i = 0; i < secondCompartment.Count; i++) {

                    Console.Write(secondCompartment[i] + " - ");

                }

                break;

            }

            Console.ReadKey();

        }

    }

}
