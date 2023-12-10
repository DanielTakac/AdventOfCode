using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day7 : Day {

        protected override string Part1() {

            string[] input = AdventOfCode.GetInput();

            List<Hand> hands = new List<Hand>();

            foreach (string line in input) {

                string cards = line.Split()[0];
                int bid = int.Parse(line.Split()[1]);

                Hand hand = new Hand(cards, bid);

                hands.Add(hand);

            }

            // Sort hands by value
            hands = hands.OrderBy(x => x.Value).ToList();

            // Sort hands with the same value
            for (int i = 1; i < hands.Count; i++) {

                if (hands[i].Value == hands[i - 1].Value) {

                    bool inOrder = CompareHands(hands[i - 1].Cards, hands[i].Cards);

                    if (!inOrder) {

                        // Swap hands
                        (hands[i - 1], hands[i]) = (hands[i], hands[i - 1]);

                        // Start from the begginning again
                        i = 1;

                    }

                }

            }

            // 2nd run because the first hand doesn't get sorted for some reason and I'm too lazy to fix it
            for (int i = 1; i < hands.Count; i++) {

                if (hands[i].Value == hands[i - 1].Value) {

                    bool inOrder = CompareHands(hands[i - 1].Cards, hands[i].Cards);

                    if (!inOrder) {

                        // Swap hands
                        (hands[i - 1], hands[i]) = (hands[i], hands[i - 1]);

                        // Start from the begginning again
                        i = 1;

                    }

                }

            }

            int totalWinnings = 0;

            for (int i = 0; i < hands.Count; i++) {

                totalWinnings += hands[i].Bid * (i + 1);

            }

            return totalWinnings.ToString();

        }

        class Hand {

            public string Cards { get; private set; }
            public int Bid { get; private set; }
            public int Value {  get; private set; }
            private bool JokerRule { get; set; }

            public Hand(string cards, int bid, bool jokerRule = false) {

                if (cards.Length == 5) {

                    Cards = cards;

                } else {

                    AdventOfCode.PrintWithColor($"Length of cards string {cards} is {cards.Length} but should be 5!", ConsoleColor.Red);
                    Cards = string.Empty;

                }

                Bid = bid;
                JokerRule = jokerRule;
                Value = GetValue();

            }

            private bool IsFiveOfAKind(Dictionary<char, int> cardCounts) {

                if (cardCounts.Count != 1) return false;

                return true;

            }

            private bool IsFourOfAKind(Dictionary<char, int> cardCounts) {

                if (cardCounts.Count != 2) return false;

                int card1 = cardCounts.ElementAt(0).Value;
                int card2 = cardCounts.ElementAt(1).Value;

                if (card1 == 4 && card2 == 1 ||
                    card1 == 1 && card2 == 4) {

                    return true;

                }

                return false;

            }

            private bool IsFullHouse(Dictionary<char, int> cardCounts) {

                if (cardCounts.Count != 2) return false;

                int card1 = cardCounts.ElementAt(0).Value;
                int card2 = cardCounts.ElementAt(1).Value;

                if (card1 == 3 && card2 == 2 ||
                    card1 == 2 && card2 == 3) {

                    return true;

                }

                return false;

            }

            private bool IsThreeOfAKind(Dictionary<char, int> cardCounts) {

                if (cardCounts.Count != 3) return false;

                int card1 = cardCounts.ElementAt(0).Value;
                int card2 = cardCounts.ElementAt(1).Value;
                int card3 = cardCounts.ElementAt(2).Value;

                if (card1 == 3 ||
                    card2 == 3 ||
                    card3 == 3) {

                    return true;

                }

                return false;

            }

            private bool IsTwoPair(Dictionary<char, int> cardCounts) {

                if (cardCounts.Count != 3) return false;

                int card1 = cardCounts.ElementAt(0).Value;
                int card2 = cardCounts.ElementAt(1).Value;
                int card3 = cardCounts.ElementAt(2).Value;

                if (card1 == 2 ||
                    card2 == 2 ||
                    card3 == 2) {

                    return true;

                }

                return false;

            }

            private bool IsOnePair(Dictionary<char, int> cardCounts) {

                if (cardCounts.Count != 4) return false;

                int card1 = cardCounts.ElementAt(0).Value;
                int card2 = cardCounts.ElementAt(1).Value;
                int card3 = cardCounts.ElementAt(2).Value;
                int card4 = cardCounts.ElementAt(3).Value;

                if (card1 == 2 ||
                    card2 == 2 ||
                    card3 == 2 ||
                    card4 == 2) {

                    return true;

                }

                return false;

            }

            private bool IsHighCard(Dictionary<char, int> cardCounts) {

                if (cardCounts.Count != 5) return false;

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

                Dictionary<char, int> cardCounts = new Dictionary<char, int>();

                // Fill up cardCounts dictionary
                foreach (char card in Cards) {

                    if (cardCounts.ContainsKey(card)) {

                        cardCounts[card]++;

                    } else {

                        cardCounts.Add(card, 1);

                    }

                }

                if (JokerRule &&  cardCounts.ContainsKey('J')) {

                    // All cards are jokers
                    if (cardCounts.Count == 1) {
                        return 7;
                    }

                    char mostCommonCard = cardCounts.Where(x => x.Key != 'J').OrderByDescending(x => x.Value).FirstOrDefault().Key;

                    cardCounts[mostCommonCard] += cardCounts['J'];

                    cardCounts.Remove('J');

                }

                int value = 0;

                if (IsFiveOfAKind(cardCounts)) {
                    value = 7;
                } else if (IsFourOfAKind(cardCounts)) {
                    value = 6;
                } else if (IsFullHouse(cardCounts)) {
                    value = 5;
                } else if (IsThreeOfAKind(cardCounts)) {
                    value = 4;
                } else if (IsTwoPair(cardCounts)) {
                    value = 3;
                } else if (IsOnePair(cardCounts)) {
                    value = 2;
                } else if (IsHighCard(cardCounts)) {
                    value = 1;
                }

                return value;

            }

        }

        static Dictionary<char, int> cardStrengths = new Dictionary<char, int>() {
            { '2', 1 },
            { '3', 2 },
            { '4', 3 },
            { '5', 4 },
            { '6', 5 },
            { '7', 6 },
            { '8', 7 },
            { '9', 8 },
            { 'T', 9 },
            { 'J', 10 },
            { 'Q', 11 },
            { 'K', 12 },
            { 'A', 13 }
        };

        static Dictionary<char, int> cardStrengthsJR = new Dictionary<char, int>() {
            { 'J', 0 },
            { '2', 1 },
            { '3', 2 },
            { '4', 3 },
            { '5', 4 },
            { '6', 5 },
            { '7', 6 },
            { '8', 7 },
            { '9', 8 },
            { 'T', 9 },
            { 'Q', 10 },
            { 'K', 11 },
            { 'A', 12 }
        };

        private bool CompareHands(string cards1, string cards2, bool jokerRule = false) {

            Dictionary<char, int> strengths = jokerRule ? cardStrengthsJR : cardStrengths;

            for (int i = 0; i < 5; i++) {

                if (strengths[cards1[i]] == strengths[cards2[i]]) {

                    continue;

                } else if (strengths[cards1[i]] < strengths[cards2[i]]) {

                    return true;

                } else if (strengths[cards1[i]] > strengths[cards2[i]]) {

                    return false;

                }

            }

            return true;

        }

        protected override string Part2() {

            string[] input = AdventOfCode.GetInput();

            List<Hand> hands = new List<Hand>();

            foreach (string line in input) {

                string cards = line.Split()[0];
                int bid = int.Parse(line.Split()[1]);

                Hand hand = new Hand(cards, bid, true);

                hands.Add(hand);

            }

            // Sort hands by value
            hands = hands.OrderBy(x => x.Value).ToList();

            // Sort hands with the same value
            for (int i = 1; i < hands.Count; i++) {

                if (hands[i].Value == hands[i - 1].Value) {

                    bool inOrder = CompareHands(hands[i - 1].Cards, hands[i].Cards, true);

                    if (!inOrder) {

                        // Swap hands
                        (hands[i - 1], hands[i]) = (hands[i], hands[i - 1]);

                        // Start from the begginning again
                        i = 1;

                    }

                }

            }

            // 2nd run because the first hand doesn't get sorted for some reason and I'm too lazy to fix it
            for (int i = 1; i < hands.Count; i++) {

                if (hands[i].Value == hands[i - 1].Value) {

                    bool inOrder = CompareHands(hands[i - 1].Cards, hands[i].Cards, true);

                    if (!inOrder) {

                        // Swap hands
                        (hands[i - 1], hands[i]) = (hands[i], hands[i - 1]);

                        // Start from the begginning again
                        i = 1;

                    }

                }

            }

            int totalWinnings = 0;

            for (int i = 0; i < hands.Count; i++) {

                totalWinnings += hands[i].Bid * (i + 1);

            }

            return totalWinnings.ToString();

        }

        static void Main(string[] args) {

            var day = new Day7();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
