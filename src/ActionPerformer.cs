using Nancy.Simple.Models;

namespace Nancy.Simple
{
    public class ActionPerformer
    {
        public int Call(GameState state)
        {
            return state.MinimumRaise;
        }

        public int Check(GameState state)
        {
            return 0;
        }

        public int Fold(GameState state)
        {
            return 0;
        }

        public int Raise(GameState state, int amount)
        {
            return Call(state) + amount;
        }

        public int AllIn(GameState state)
        {
            return int.MaxValue;
        }
    }
}