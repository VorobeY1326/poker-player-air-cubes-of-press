using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.Models
{
    public class PokerHandsDetector
    {
        public PokerHands Detect(GameState state)
        {
            var closedCards = state.Players[state.InAction].HoleCards;
            var openCards = state.CommunityCards;

            return Detect(closedCards, openCards);
        }

        public PokerHands Detect(IList<Card> closedCards, IList<Card> openCards)
        {
            var count = openCards.Count;
            for (var i = 0; i < 5 - count; i++)
            {
                openCards.Add(null);
            }

            return new[]
            {
                new[] {closedCards[0], openCards[1], openCards[2], openCards[3], openCards[4]},
                new[] {closedCards[0], openCards[0], openCards[2], openCards[3], openCards[4]},
                new[] {closedCards[0], openCards[0], openCards[1], openCards[3], openCards[4]},
                new[] {closedCards[0], openCards[0], openCards[1], openCards[2], openCards[4]},
                new[] {closedCards[0], openCards[0], openCards[1], openCards[2], openCards[3]},
                new[] {closedCards[1], openCards[1], openCards[2], openCards[3], openCards[4]},
                new[] {closedCards[1], openCards[0], openCards[2], openCards[3], openCards[4]},
                new[] {closedCards[1], openCards[0], openCards[1], openCards[3], openCards[4]},
                new[] {closedCards[1], openCards[0], openCards[1], openCards[2], openCards[4]},
                new[] {closedCards[1], openCards[0], openCards[1], openCards[2], openCards[3]},
                new[] {closedCards[0], closedCards[1], openCards[0], openCards[1], openCards[2]},
                new[] {closedCards[0], closedCards[1], openCards[0], openCards[1], openCards[3]},
                new[] {closedCards[0], closedCards[1], openCards[0], openCards[1], openCards[4]},
                new[] {closedCards[0], closedCards[1], openCards[0], openCards[2], openCards[3]},
                new[] {closedCards[0], closedCards[1], openCards[0], openCards[2], openCards[4]},
                new[] {closedCards[0], closedCards[1], openCards[0], openCards[3], openCards[4]},
                new[] {closedCards[0], closedCards[1], openCards[1], openCards[2], openCards[3]},
                new[] {closedCards[0], closedCards[1], openCards[1], openCards[2], openCards[4]},
                new[] {closedCards[0], closedCards[1], openCards[1], openCards[3], openCards[4]}
            }
                .Select(e => e.Where(g => g != null).ToArray())
                .Select(Detect)
                .OrderByDescending(e => e)
                .FirstOrDefault();
        }

        public PokerHands Detect(IEnumerable<Card> cards)
        {
            var cardsArray = cards.ToArray();

            if (cardsArray.Length == 5 && IsSameSuit(cardsArray) && IsConsequant(cardsArray))
            {
                return PokerHands.StraightFlush;
            }

            var countsArray = cardsArray
                .GroupBy(e => e.Rank_int)
                .ToDictionary(e => e.Key, e => e.ToList())
                .Select(e => e.Value.Count)
                .OrderByDescending(e => e)
                .ToArray();

            if (countsArray[0] == 4)
            {
                return PokerHands.FourOfAKind;
            }

            if (countsArray[0] == 3 && countsArray[1] == 2)
            {
                return PokerHands.FullHouse;
            }

            if (cardsArray.Length == 5 && IsSameSuit(cardsArray))
            {
                return PokerHands.Flush;
            }

            if (cardsArray.Length == 5 && IsConsequant(cardsArray))
            {
                return PokerHands.Straight;
            }

            if (countsArray[0] == 3)
            {
                return PokerHands.ThreeOfAKind;
            }

            if (countsArray.Length > 1 && countsArray[0] == 2 && countsArray[1] == 2)
            {
                return PokerHands.TwoPair;
            }

            if (countsArray[0] == 2)
            {
                return PokerHands.OnePair;
            }

            return PokerHands.HighCard;
        }

        private static bool IsConsequant(IEnumerable<Card> cards)
        {
            var orderedCards = cards.OrderBy(e => e.Rank_int).ToArray();

            for (var i = 1; i < orderedCards.Length; i++)
            {
                if (orderedCards[i].Rank_int - orderedCards[i - 1].Rank_int != 1)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsSameSuit(IEnumerable<Card> cards)
        {
            return cards.Select(e => e.Suit).Distinct().Count() == 1;
        }
    }
}