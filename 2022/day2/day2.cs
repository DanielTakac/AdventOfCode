using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day2 {

        static void Main(string[] args) {

            string[] input = AdventOfCode.GetInput();

            int score1 = 0;
            int score2 = 0;

            foreach (string line in input) {

                Console.WriteLine(line.Substring(0, 1) + " - " + line.Substring(2, 1));

                char opponentPlay = line.Substring(0, 1)[0];
                char myPlay = line.Substring(2, 1)[0];

                // A - Rock B - Paper C - Scissors
                // X - Rock Y- Paper Z - Scissors

                // Part 1

                switch (myPlay) {

                    case 'X': score1 += 1; break;
                    case 'Y': score1 += 2; break;
                    case 'Z': score1 += 3; break;

                }

                if ((myPlay == 'X' && opponentPlay == 'A') || (myPlay == 'Y' && opponentPlay == 'B') || (myPlay == 'Z' && opponentPlay == 'C')) {

                    score1 += 3;

                } else if ((myPlay == 'X' && opponentPlay == 'C') || (myPlay == 'Y' && opponentPlay == 'A') || (myPlay == 'Z' && opponentPlay == 'B')) {

                    score1 += 6;

                }

                // Part 2

                switch (myPlay) {

                    case 'X':

                        switch (opponentPlay) {

                            case 'A': score2 += 3; break;
                            case 'B': score2 += 1; break;
                            case 'C': score2 += 2; break;

                        }

                        break;

                    case 'Y':

                        score2 += 3;

                        switch (opponentPlay) {

                            case 'A': score2 += 1; break;
                            case 'B': score2 += 2; break;
                            case 'C': score2 += 3; break;

                        }

                        break;

                    case 'Z':

                        score2 += 6;

                        switch (opponentPlay) {

                            case 'A': score2 += 2; break;
                            case 'B': score2 += 3; break;
                            case 'C': score2 += 1; break;

                        }

                        break;
                
                }

            }

            AdventOfCode.PrintWithColor($"\nPart 1 score: {score1}");
            AdventOfCode.PrintWithColor($"Part 2 score: {score2}");

            Console.ReadKey();

        }

    }

}
