using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day6 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput(path: "demo1.txt");

            int firstPacketMarker = 0;
            int firstMessageMarker = 0;

            for (int i = 3; i < input[0].Length; i++) {

                string lastFour = input[0].Substring(i - 3, 4);

                bool allUnique = true;

                for (int x = 0; x < lastFour.Length; x++) {

                    for (int y = x + 1; y < lastFour.Length; y++) {

                        if (lastFour[x] == lastFour[y]) {

                            allUnique = false;

                        }

                    }

                }

                if (allUnique) {

                    firstPacketMarker = i + 1;

                    break;

                }

            }

            for (int i = 13; i < input[0].Length; i++) {

                string lastFourteen = input[0].Substring(i - 13, 14);

                bool allUnique = true;

                for (int x = 0; x < lastFourteen.Length; x++) {

                    for (int y = x + 1; y < lastFourteen.Length; y++) {

                        if (lastFourteen[x] == lastFourteen[y]) {

                            allUnique = false;

                        }

                    }

                }

                if (allUnique) {

                    firstMessageMarker = i + 1;

                    break;

                }

            }

            AdventOfCode.PrintWithColor($"Part 1: {firstPacketMarker}");
            AdventOfCode.PrintWithColor($"Part 2: {firstMessageMarker}");

            Console.ReadKey();

        }

    }

}
