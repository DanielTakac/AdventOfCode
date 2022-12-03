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
            List<char> commonItems = new List<char>();

            Dictionary<char, int> priorityPerItem = new Dictionary<char, int>();

            char[] lowerCaseLetters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] upperCaseLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            int counter = 1;

            foreach (char item in lowerCaseLetters) priorityPerItem.Add(item, counter++);

            counter = 27;

            foreach (char item in upperCaseLetters) priorityPerItem.Add(item, counter++);

            int totalPriority = 0;

            int lines = 0;

            foreach (string line in readText) {

                lines++;

                firstCompartment = new List<char>();
                secondCompartment = new List<char>();

                for (int i = 0; i < line.Count(); i++) {

                    if (i < line.Count() / 2) {

                        firstCompartment.Add(line[i]);

                    } else {

                        secondCompartment.Add(line[i]);

                    }

                }

                void FindCommonItem() {

                    for (int i = 0; i < firstCompartment.Count(); i++) {

                        for (int j = 0; j < secondCompartment.Count(); j++) {

                            if (firstCompartment[i] == secondCompartment[j]) {

                                commonItems.Add(firstCompartment[i]);

                                return;

                            }

                        }

                    }

                }

                FindCommonItem();

                Console.WriteLine("\n\nFirst compartment: " + firstCompartment.Count());
                Console.WriteLine("Second compartment: " + secondCompartment.Count());

                Console.WriteLine("First compartment: ");

                for (int i = 0; i < firstCompartment.Count; i++)
                    Console.Write(firstCompartment[i] + " - ");

                Console.WriteLine("\nSecond compartment: ");

                for (int i = 0; i < secondCompartment.Count; i++)
                    Console.Write(secondCompartment[i] + " - ");

            }

            foreach (char item in commonItems) {

                totalPriority += priorityPerItem[item];

            }

            Console.WriteLine("\nCommon items: ");

            for (int i = 0; i < commonItems.Count; i++)
                Console.WriteLine(commonItems[i]);

            Console.WriteLine($"\n\nLines: {lines}\nCommon Items: {commonItems.Count()}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\nTotal priority: {totalPriority}");
            Console.ResetColor();

            Console.ReadKey();

        }

    }

}
