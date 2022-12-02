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

                Console.WriteLine(line.Substring(0, 1) + " - " + line.Substring(2, 1));

                char opponentPlay = line.Substring(0, 1)[0];
                char myPlay = line.Substring(2, 1)[0];

                // A - Rock B - Paper C - Scissors
                // X - Rock Y- Paper Z - Scissors

                switch (myPlay) {

                    case 'X': score += 1; break;
                    case 'Y': score += 2; break;
                    case 'Z': score += 3; break;

                }

                if ((myPlay == 'X' && opponentPlay == 'A') || (myPlay == 'Y' && opponentPlay == 'B') || (myPlay == 'Z' && opponentPlay == 'C')) {

                    score += 3;

                } else if ((myPlay == 'X' && opponentPlay == 'C') || (myPlay == 'Y' && opponentPlay == 'A') || (myPlay == 'Z' && opponentPlay == 'B')) {

                    score += 6;

                } else if ((myPlay == 'X' && opponentPlay == 'B') || (myPlay == 'Y' && opponentPlay == 'C') || (myPlay == 'Z' && opponentPlay == 'A')) {

                    score += 0;

                }

            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nFinal score: {score}");
            Console.ResetColor();

        }

    }

}
