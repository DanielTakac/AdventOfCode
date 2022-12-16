using day13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode {

    class Day13 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput();

            int part1 = 0;

            int j = 1;

            for (int i = 0; i < input.Length; i += 3) {

                List<object> packet1 = ListParser.ParseList(ListParser.StringToQueue(input[i].Trim()));
                List<object> packet2 = ListParser.ParseList(ListParser.StringToQueue(input[i + 1].Trim()));

                if (Packets.CompareElements(packet1, packet2) != 1) {

                    part1 += j;

                }

                j++;

            }

            AdventOfCode.PrintWithColor($"Part 1: {part1}");

            Console.ReadKey();
            
        }

    }

}
