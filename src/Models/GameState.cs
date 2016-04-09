using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nancy.Simple.Models
{
    public class GameState
    {
        [JsonProperty(PropertyName = "tournament_id")]
        public string TournamentId { get; set; }
        [JsonProperty(PropertyName = "game_id")]
        public string GameId { get; set; }
        public int Round { get; set; }
        [JsonProperty(PropertyName = "bet_index")]
        public int BetIndex { get; set; }
        [JsonProperty(PropertyName = "small_blind")]
        public int SmallBlind { get; set; }
        [JsonProperty(PropertyName = "current_buy_in")]
        public int CurrentBuyIn { get; set; }
        public int Pot { get; set; }
        [JsonProperty(PropertyName = "minimum_raise")]
        public int MinimumRaise { get; set; }
        public int Dealer { get; set; }
        public int Orbits { get; set; }
        [JsonProperty(PropertyName = "in_action")]
        public int InAction { get; set; }
        public IList<Player> Players { get; set; }
        [JsonProperty(PropertyName = "community_cards")]
        public IList<Card> CommunityCards { get; set; }
    }
}