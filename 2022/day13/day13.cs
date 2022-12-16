using day13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode {

    class Day13 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput(path: "demo.txt");

            Console.WriteLine("length: " + input.Length);

            for (int i = 0; i < input.Length; i += 3) {

                AdventOfCode.PrintWithColor($"{i}: {input[i]} vs {input[i + 1]}", ConsoleColor.Cyan);

                List<object> packet1 = ListParser.ParseList(ListParser.StringToQueue(input[i].Trim()));
                List<object> packet2 = ListParser.ParseList(ListParser.StringToQueue(input[i + 1].Trim()));

                Console.WriteLine(Packets.CompareElements(packet1, packet2));

            }

            Console.ReadKey();
            
        }

    }

}
