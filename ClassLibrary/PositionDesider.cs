using System.Linq;
using ClassLibrary.Models;

namespace ClassLibrary
{
    public class PositionDesider
    {
        public double GetPositionGoodness_Pair(Player me, GameState state)
        {
            var cardA = me.HoleCards[0];
            var cardB = me.HoleCards[1];
            var ok = new[] { "8", "9", "10", "J", "Q", "K", "A" };
            if (cardA.Rank == cardB.Rank && ok.Contains(cardA.Rank))
                return 1;
            return 0;
        }

        //returns from 0 to 1
        public double GetPositionGoodness(Player me, GameState state)
        {
            var cardA = me.HoleCards[0];
            var cardB = me.HoleCards[1];
            if (cardA.Rank == cardB.Rank && cardA.Rank_int > 6)
            {
                return 1;
            }

            if (cardA.Suit == cardB.Suit)
            {
                return 1;
            }

            if (cardA.Rank_int > 9 && cardB.Rank_int > 9)
            {
                return 1;
            }

            return 0;
        }
    }
}