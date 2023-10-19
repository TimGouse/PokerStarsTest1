using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerStarsTest1
{
    public class PokerHandSummary
    {
        public int TotalHands { get; set; }
        public decimal TotalWinnings { get; set; }
        public Dictionary<string, decimal> PlayerWins { get; set; }
        //public Dictionary<string, decimal> PlayerLosses { get; set; }

        public PokerHandSummary()
        {
            TotalHands = 0;
            TotalWinnings = 0;
            PlayerWins = new Dictionary<string, decimal>();
            //PlayerLosses = new Dictionary<string, decimal>();
        }
    }
}
