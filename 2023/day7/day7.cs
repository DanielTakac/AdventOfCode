using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day7 : Day {

        protected override string Part1() {

            string[] input = AdventOfCode.GetInput("example.txt");

            string[] handTypes = {
                "none",
                "High card - 23456",
                "One pair - A23A4",
                "Two pair - 23432",
                "Three of a kind - TTT98",
                "Full house - 23332",
                "Four of a kind - AA8AA",
                "Five of a kind - AAAAA",
            };

            Hand testHand = new Hand("XXYXX");

            Console.WriteLine(testHand.Cards + ": " + testHand.GetValue() + " " + handTypes[testHand.GetValue()]);

            return string.Empty;

        }

        class Hand {

            public string Cards { get; set; }
            public string Bid { get; set; }
            public int Value {  get; set; }

            public Hand(string cards) {

                if (cards.Length == 5) {

                    Cards = cards;

                } else {

                    AdventOfCode.PrintWithColor($"Length of cards string {cards} is {cards.Length} but should be 5!", ConsoleColor.Red);
                    Cards = string.Empty;

                }

                Bid = string.Empty;
                Value = GetValue();

            }

            private bool IsFiveOfAKind() {

                char firstCard = Cards[0];

                foreach (char card in Cards) {

                    if (card != firstCard) {

                        return false;

                    }

                }

                return true;

            }

            private bool IsFourOfAKind() {

                char firstCard = Cards[0];
                char secondCard = Cards[1];

                int firstCardOccurrences = 0;
                int secondCardOccurrences = 0;

                foreach (char card in Cards) {

                    if (card == firstCard) {

                        firstCardOccurrences++;

                    }

                    if (card == secondCard) {

                        secondCardOccurrences++;

                    }

                }

                if (firstCardOccurrences == 4 || secondCardOccurrences == 4) {
                    return true;
                } else {
                    return false;
                }

            }

            private bool IsFullHouse() {

                return true;

            }

            private bool IsThreeOfAKind() {

                return true;

            }

            private bool IsTwoPair() {

                return true;

            }

            private bool IsOnePair() {

                return true;

            }

            private bool IsHighCard() {

                return true;

            }

            public int GetValue() {

                // Five of a kind: AAAAA = 7
                // Four of a kind: AA8AA = 6
                // Full house: 23332 = 5
                // Three of a kind: TTT98 = 4
                // Two pair: 23432 = 3
                // One pair: A23A4 = 2
                // High card: 23456 = 1

                int value = 0;

                if (IsFiveOfAKind()) {
                    value = 7;
                } else if (IsFourOfAKind()) {
                    value = 6;
                } else if (IsFullHouse()) {
                    value = 5;
                } else if (IsThreeOfAKind()) {
                    value = 4;
                } else if (IsTwoPair()) {
                    value = 3;
                } else if (IsOnePair()) {
                    value = 2;
                } else if (IsHighCard()) {
                    value = 1;
                }

                return value;

            }

        }

        protected override string Part2() {

            return string.Empty;

        }

        static void Main(string[] args) {

            var day = new Day7();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
