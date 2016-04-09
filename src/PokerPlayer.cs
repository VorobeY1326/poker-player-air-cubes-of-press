using Nancy.Simple.Models;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
	public static class PokerPlayer
	{
		public static readonly string VERSION = "Air v1.0.2";

        private static PositionDesider desider = new PositionDesider();
        private static ActionPerformer performer = new ActionPerformer();

		public static int BetRequest(JObject gameState)
		{
		    var state = gameState.ToObject<GameState>();

		    var me = state.Players[state.InAction];

		    if (desider.GetPositionGoodness(me, state) > 0.5)
		    {
		        return performer.Raise(state, me.Stack/2);
		    }

		    var needToCall = performer.Call(state);

		    return needToCall < 0.1 * me.Stack ? performer.Call(state) : performer.Check(state);
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}
	}
}
