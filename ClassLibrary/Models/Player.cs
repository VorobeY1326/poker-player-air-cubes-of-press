using System.Collections.Generic;
using Newtonsoft.Json;

namespace ClassLibrary.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PlayerStatus Status { get; set; }
        public string Version { get; set; }
        public int Stack { get; set; }
        public int Bet { get; set; }
        [JsonProperty(PropertyName = "hole_cards")]
        public IList<Card> HoleCards { get; set; }
    }
}