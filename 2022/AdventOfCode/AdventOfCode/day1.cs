using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3B2Cislica27 {

    class Program {

        static void Main(string[] args) {

            string path = @"input.txt";
            
            string[] readText = File.ReadAllLines(path);

            List<int> elfCalories = new List<int>();

            foreach (string line in readText) {

                if (line != " " || line != "") {

                    Console.WriteLine("(" + line + ")");
                    
                }

                Console.WriteLine("space");

            }

        }

    }

}
