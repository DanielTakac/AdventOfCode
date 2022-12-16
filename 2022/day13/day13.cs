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

                List<object> packet1 = ListParser(input[i].Trim());
                List<object> packet2 = ListParser(input[i + 1].Trim());

                

            }

            Console.WriteLine(ListToString(new List<object>() { 1, new List<object>() { 2, 3, 4 }, 5, new List<object>() { 6, 7, 8}, 9, 10 }));

            Console.ReadKey();
            
        }

        static public List<object> ListParser(string input) {

            List<object> packet = new List<object>();



            return new List<object>();
            
        }

        static public string ListToString(List<object> objects) {

            if (objects.Count == 0) {

                return "[]";

            } else if (objects.Count == 1 && objects[0] is int) {

                return $"[{objects[0]}]";

            } else {

                string yo(List<object> list) {

                    bool allNumbers = true;

                    string packet = string.Empty;

                    packet += "[";

                    for (int i = 0; i < list.Count; i++) {

                        if (list[i] is int) {



                        }

                        packet += objects[i];

                        if (i != objects.Count - 1)
                            packet += ",";

                    }

                    packet += "]";

                    return packet;


                }

                return yo(objects);

            }

        }

    }

}
