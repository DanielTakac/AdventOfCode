using day13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode {

    class Day13 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput(path: "demo.txt");

            /*
             * [1,1,3,1,1]
             * [1,1,5,1,1]

             * [[1],[2,3,4]]
             * [[1],4]

             * [9]
             * [[8,7,6]]

             * [[4,4],4,4]
             * [[4,4],4,4,4]

             * [7,7,7,7]
             * [7,7,7]

             * []
             * [3]

             * [[[]]]
             * [[]]

             * [1,[2,[3,[4,[5,6,7]]]],8,9]
             * [1,[2,[3,[4,[5,6,0]]]],8,9]
             * */

            Console.WriteLine("length: " + input.Length);

            for (int i = 0; i < input.Length; i += 3) {

                AdventOfCode.PrintWithColor($"{i}: {input[i]} vs {input[i + 1]}", ConsoleColor.Cyan);

                // List<object> packet1 = ListParser(input[i].Trim());
                // List<object> packet2 = ListParser(input[i + 1].Trim());

                

            }



            // Console.WriteLine(ListParser.ListToString(new List<object>() { 1, new List<object>() { 2, 3, new List<object>(), 4 }, 5, new List<object>() { new List<object>() }, new List<object>() { 6, 7, 8}, 9, new List<object>(), 10 }));

            Console.ReadKey();
            
        }

    }

}
