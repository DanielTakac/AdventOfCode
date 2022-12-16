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

            // Part 2

            var firstDividerPacket = new List<object>() { new List<object>() { new List<object>() { 2 } } };
            var secondDividerPacket = new List<object>() { new List<object>() { new List<object>() { 6 } } };

            List<List<object>> packets = new List<List<object>>() { firstDividerPacket, secondDividerPacket };
            
            for (int i = 0; i < input.Length; i++) {

                if (input[i] == string.Empty) continue;

                packets.Add(ListParser.ParseList(ListParser.StringToQueue(input[i].Trim())));

            }

            Comparison<List<object>> comparison = (x, y) => Packets.CompareElements(x, y);

            packets.Sort(comparison);

            int indexOfFirstDividerPacket = packets.IndexOf(firstDividerPacket) + 1;
            int indexOfSecondDividerPacket = packets.IndexOf(secondDividerPacket) + 1;

            int part2 = indexOfFirstDividerPacket * indexOfSecondDividerPacket;

            AdventOfCode.PrintWithColor($"Part 1: {part1}");
            AdventOfCode.PrintWithColor($"Part 2: {part2}");

            Console.ReadKey();
            
        }

    }

}
