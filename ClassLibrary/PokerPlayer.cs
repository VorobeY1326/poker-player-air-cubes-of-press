using System;
using ClassLibrary.Models;
using Newtonsoft.Json.Linq;

namespace ClassLibrary
{
	public static class PokerPlayer
	{
		public static readonly string VERSION = "Air v1.0.4r";

        public static Random random = new Random();

        private static PositionDesider desider = new PositionDesider();
        private static ActionPerformer performer = new ActionPerformer();

		public static int BetRequest(JObject gameState)
		{
		    var state = gameState.ToObject<GameState>();
		    var me = state.Players[state.InAction];

		    Console.WriteLine("{3} Step {0}-{1}, money {2}", state.Round, state.BetIndex, me.Stack, DateTime.Now);

		    return RunDecisionTrees(me, state);
		}

	    private static int RunDecisionTrees(Player me, GameState state)
	    {
	        var positionGoodness = desider.GetPositionGoodness_Pair(me, state);
	        Console.WriteLine("Goodness {0}", positionGoodness);
	        if (positionGoodness > 0.5)
	        {
	            if (random.Next(7) == 1)
	            {
	                Console.WriteLine("ALLIN");
	                return performer.AllIn(state);
	            }

	            var toAdd = performer.Raise(state, me, me.Stack/2);
	            Console.WriteLine("Raise - adding {0}", toAdd);
	            return toAdd;
	        }

            if (random.Next(20) == 1)
            {
                Console.WriteLine("ALLIN");
                return performer.AllIn(state);
            }

	        var needToCall = performer.Call(state, me);

	        var letsCall = needToCall < 0.1*me.Stack;
	        var toAdd2 = letsCall ? performer.Call(state, me) : performer.Check(state);
	        Console.WriteLine("Letscall={0} adding {1}", letsCall, toAdd2);
	        return toAdd2;
	    }

	    public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}
	}
}
