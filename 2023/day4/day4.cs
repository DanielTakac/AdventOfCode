using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day4 : Day {

        protected override string Part1() {

            string[] input = AdventOfCode.GetInput();

            int points = 0;

            foreach (string card in input) {

                int[] winningNums = GetWinningNumbers(card);
                int[] myNums = GetMyNumbers(card);

                int pointsOnCard = 0;

                foreach (int num in myNums) {

                    if (winningNums.Contains(num)) {

                        if (pointsOnCard == 0) {

                            pointsOnCard = 1;

                        } else {

                            pointsOnCard *= 2;

                        }

                    }

                }

                points += pointsOnCard;

            }

            return points.ToString();

        }

        private int[] GetWinningNumbers(string card) {

            string numsStr = card.Split('|')[1].Trim();

            int[] nums = numsStr.Split(' ').Where(s => s != "").Select(int.Parse).ToArray();

            return nums;

        }

        private int[] GetMyNumbers(string card) {

            string splitCard = card.Split(':')[1].Trim();
            string numsStr = splitCard.Split('|')[0].Trim();

            int[] nums = numsStr.Split(' ').Where(s => s != "").Select(int.Parse).ToArray();

            return nums;

        }

        private int CheckCard(string[] cards, int i) {

            iterations++;

            int iteration = iterations;

            AdventOfCode.PrintWithColor("iteration " + iterations, ConsoleColor.Magenta);

            int[] winningNums = GetWinningNumbers(cards[i]);
            int[] myNums = GetMyNumbers(cards[i]);

            int copies = 0;

            foreach (int num in myNums) {

                if (winningNums.Contains(num)) {

                    copies++;

                }

            }

            int cardsWon = 0;

            for (int j = 1; j <= copies; j++) {

                cardsWon += CheckCard(cards, i + j);

            }

            AdventOfCode.PrintWithColor($"iteration {iteration} finished: {copies} copies and {cardsWon} cards won");

            return copies + cardsWon;

        }

        static int iterations;

        protected override string Part2() {

            string[] cards = AdventOfCode.GetInput("example.txt");

            int cardsWon = 0;

            iterations = 0;

            for (int i = 0; i < cards.Length; i++) {

                AdventOfCode.PrintWithColor($"Card {i + 1}:", ConsoleColor.Yellow);

                cardsWon += CheckCard(cards, i);

                AdventOfCode.PrintWithColor("total: " + cardsWon, ConsoleColor.Cyan);

            }

            return cardsWon.ToString();

        }

        static void Main(string[] args) {

            var day = new Day4();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
