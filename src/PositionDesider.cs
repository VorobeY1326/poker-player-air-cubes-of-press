using System.Linq;
using Nancy.Simple.Models;

namespace Nancy.Simple
{
    public class PositionDesider
    {
        //returns from 0 to 1
        public double GetPositionGoodness(Player me, GameState state)
        {
            var cardA = me.HoleCards[0];
            var cardB = me.HoleCards[0];
            var ok = new[] {"8", "9", "10", "J", "Q", "K", "A"};
            if (cardA.Rank == cardB.Rank && ok.Contains(cardA.Rank))
                return 1;
            return 0;
        }
    }
}