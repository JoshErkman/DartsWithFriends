using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Models.Match
{
    public class MatchDetail
    {
        public int MatchId { get; set; }
        public int MatchSetupId { get; set; }
        public int PlayerOneNeededScore { get; set; }
        public int PlayerTwoNeededScore { get; set; }
        public int PlayerOneAvgRoundScore { get; set; }
        public int PlayerTwoAvgRoundScore { get; set; }
        public bool IsTurn { get; set; }
    }
}
