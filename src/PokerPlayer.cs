using System.Linq;
using Nancy.Simple.Models;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
	public static class PokerPlayer
	{
		public static readonly string VERSION = "Air v1.0.1";

        private static PositionDesider desider = new PositionDesider();

		public static int BetRequest(JObject gameState)
		{
		    var state = gameState.ToObject<GameState>();
		    var me = state.Players[state.InAction];
		    return desider.GetPositionGoodness(me, state) > 0.5
                ? int.MaxValue
                : 0;
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}
	}
}
