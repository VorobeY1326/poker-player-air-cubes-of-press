using System.Collections.Generic;

namespace ClassLibrary.Models
{
    public class Card
    {
        public string Rank { get; set; }
        public string Suit { get; set; }

        public int Rank_int
        {
            get { return Ranks.IndexOf(Rank); }
        }

        public static List<string> Ranks = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
    
    }
}