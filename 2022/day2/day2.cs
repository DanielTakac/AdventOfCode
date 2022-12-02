using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day2 {

    class Day2 {

        static void Main(string[] args) {

            string path = @"input.txt";

            string[] readText = File.ReadAllLines(path);

            int score = 0;

            foreach (string line in readText) {

                Console.WriteLine(line.Substring(0, 1) + "-" + line.Substring(2, 1));
                
            }

        }

    }

}
