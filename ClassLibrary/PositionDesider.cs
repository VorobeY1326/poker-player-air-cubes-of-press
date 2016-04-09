using System.Linq;
using ClassLibrary.Models;

namespace ClassLibrary
{
    public class PositionDesider
    {
        //returns from 0 to 1
        public double GetPositionGoodness(Player me, GameState state)
        {
            var cardA = me.HoleCards[0];
            var cardB = me.HoleCards[1];
            var ok = new[] {"8", "9", "10", "J", "Q", "K", "A"};
            if (cardA.Rank == cardB.Rank && ok.Contains(cardA.Rank))
                return 1;
            return 0;
        }
    }
}