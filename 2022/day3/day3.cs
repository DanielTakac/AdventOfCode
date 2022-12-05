using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day3 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput();

            List<char> commonItems = new List<char>();

            Dictionary<char, int> priorityPerItem = new Dictionary<char, int>();

            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            int counter = 1;

            foreach (char item in letters) priorityPerItem.Add(item, counter++);

            int totalPriority = 0;

            List<char> badges = new List<char>();

            List<string> elfGroup = new List<string>();

            int totalBadgePriority = 0;

            foreach (string line in input) {

                List<char> firstCompartment = new List<char>();
                List<char> secondCompartment = new List<char>();

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

                // Part 2

                elfGroup.Add(line);

                if (elfGroup.Count() == 3) {

                    foreach (char letter in letters) {

                        if (elfGroup[0].Contains(letter) && elfGroup[1].Contains(letter) && elfGroup[2].Contains(letter)) {

                            badges.Add(letter);

                        }

                    }

                    elfGroup.Clear();

                }

            }

            foreach (char item in commonItems) totalPriority += priorityPerItem[item];
            foreach (char item in badges) totalBadgePriority += priorityPerItem[item];

            AdventOfCode.PrintWithColor($"Part 1: {totalPriority}");
            AdventOfCode.PrintWithColor($"Part 2: {totalBadgePriority}");

            Console.ReadKey();

        }

    }

}
