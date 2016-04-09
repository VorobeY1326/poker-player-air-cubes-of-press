using ClassLibrary.Models;

namespace ClassLibrary
{
    public class ActionPerformer
    {
        public int Call(GameState state, Player me)
        {
            return state.CurrentBuyIn - me.Bet;
        }

        public int Check(GameState state)
        {
            return 0;
        }

        public int Fold(GameState state)
        {
            return 0;
        }

        public int Raise(GameState state, Player me, int amount)
        {
            return Call(state, me) + amount;
        }

        public int AllIn(GameState state)
        {
            return int.MaxValue;
        }
    }
}