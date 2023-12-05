using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            int[] nums = numsStr.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            return nums;

        }

        private int[] GetMyNumbers(string card) {

            string splitCard = card.Split(':')[1].Trim();
            string numsStr = splitCard.Split('|')[0].Trim();

            int[] nums = numsStr.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            return nums;

        }

        private Tuple<int[], int[]> GetNumbers(string card) {

            string splitCard = card.Split(':')[1].Trim();
            string myNumsStr = splitCard.Split('|')[0].Trim();
            string winningNumsStr = splitCard.Split('|')[1].Trim();

            int[] myNums = myNumsStr.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] winningNums = winningNumsStr.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            return Tuple.Create(myNums, winningNums);

        }

        private int CheckCard(string[] cards, int cardId, ref List<int> cardStack) {

            cardStack.RemoveAt(0);

            string card = cards[cardId];

            Tuple<int[], int[]> nums = GetNumbers(card);

            int[] winningNums = nums.Item2;
            int[] myNums = nums.Item1;

            int cardsWon = 0;

            foreach (int num in myNums) {

                if (winningNums.Contains(num)) {

                    cardsWon++;

                    cardStack.Add(cardId + cardsWon);

                }

            }

            return cardsWon;

        }

        private int PreprocessCard(string card) {

            Tuple<int[], int[]> nums = GetNumbers(card);

            int[] winningNums = nums.Item2;
            int[] myNums = nums.Item1;

            int cardsWon = 0;

            foreach (int num in myNums) {

                if (winningNums.Contains(num)) {

                    cardsWon++;

                }

            }

            return cardsWon;

        }

        private int CheckPreprocessedCard(int[] cards, int cardId, ref List<int> cardStack) {

            cardStack.RemoveAt(0);

            int cardsWon = cards[cardId];

            for (int i = 1; i <= cardsWon; i++) {

                cardStack.Add(cardId + i);

            }

            return cardsWon;

        }

        protected override string Part2() {

            string[] cards = AdventOfCode.GetInput("input.txt");

            int cardsWon = 0;

            List<int> cardStack = new List<int>();

            int[] preprocessedCards = new int[cards.Length];

            for (int i = 0; i < preprocessedCards.Length; i++) {

                preprocessedCards[i] = PreprocessCard(cards[i]);

            }

            int[] instancesPerCard = new int[cards.Length];

            for (int i = 0; i < cards.Length; i++) {

                cardStack.Add(i);

                cardsWon++;

            }

            while (cardStack.Count != 0) {

                int cardId = cardStack[0];

                instancesPerCard[cardId]++;

                cardsWon += CheckPreprocessedCard(preprocessedCards, cardId, ref cardStack);

            }

            for (int i = 0; i < instancesPerCard.Length; i++){

                if (instancesPerCard[i] != 0) {

                    AdventOfCode.PrintWithColor(i + 1 + ": " + instancesPerCard[i], ConsoleColor.Cyan);

                }

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
