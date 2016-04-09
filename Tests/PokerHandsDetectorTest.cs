using System.Collections.Generic;
using ClassLibrary.Models;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PokerHandsDetectorTest
    {
        [Test]
        [TestCaseSource("TestData")]
        public void Test(IEnumerable<Card> cards, PokerHands expected)
        {
            var detector = new PokerHandsDetector();

            var pokerHands = detector.Detect(cards);

            Assert.AreEqual(expected, pokerHands);
        }

        [Test]
        public void TestCards()
        {
            var spades2 = new Card { Rank = "2", Suit = "k" };
            var hearts2 = new Card { Rank = "3", Suit = "b" };
            var hearts21 = new Card { Rank = "3", Suit = "c" };
            var hearts22 = new Card { Rank = "2", Suit = "p" };
            var hearts23 = new Card { Rank = "3", Suit = "p" };

            var detector = new PokerHandsDetector();

            var pokerHands = detector.Detect(new List<Card> {spades2, hearts2}, new List<Card> {hearts21, hearts22, hearts23});

            var b = pokerHands >= PokerHands.ThreeOfAKind;

            Assert.AreEqual(PokerHands.FullHouse, pokerHands);
        }

        private static IEnumerable<TestCaseData> TestData()
        {
            var spades2 = new Card { Rank = "2", Suit = "spades" };
            var hearts2 = new Card { Rank = "2", Suit = "hearts" };
            var diamonds2 = new Card { Rank = "2", Suit = "diamonds" };
            var clubs2 = new Card { Rank = "2", Suit = "clubs" };
            var spades3 = new Card { Rank = "3", Suit = "spades" };
            var hearts3 = new Card { Rank = "3", Suit = "hearts" };
            var spades4 = new Card { Rank = "4", Suit = "spades" };
            var spades5 = new Card { Rank = "5", Suit = "spades" };
            var spades6 = new Card { Rank = "6", Suit = "spades" };

            yield return new TestCaseData(new[] {spades3, hearts2}, PokerHands.HighCard);
            yield return new TestCaseData(new[] {spades2, hearts2}, PokerHands.OnePair);
            yield return new TestCaseData(new[] {spades2, hearts2, spades3, hearts3}, PokerHands.TwoPair);
            yield return new TestCaseData(new[] {spades2, hearts2, diamonds2, hearts3}, PokerHands.ThreeOfAKind);
            yield return new TestCaseData(new[] {hearts2, spades3, spades4, spades5, spades6}, PokerHands.Straight);
            yield return new TestCaseData(new[] {hearts2, spades3, spades4, spades5, spades6}, PokerHands.Flush);
            yield return new TestCaseData(new[] {spades2, hearts2, diamonds2, clubs2}, PokerHands.FourOfAKind);
        }
    }
}