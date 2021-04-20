using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Data
{
    public class Match
    {
        public int MatchId { get; set; }

        [ForeignKey(nameof(MatchSetup))]
        public int MatchSetupId { get; set; }
        public virtual MatchSetup MatchSetup { get; set; }

        public int PlayerOneNeededScore { get; set; } = 501;
        public int PlayerTwoNeededScore { get; set; } = 501;
        public int SetScore { get; set; }
        public int LegScore { get; set; }
        public int PlayerOneAvgRoundScore { get; set; }
        public int PlayerTwoAvgRoundScore { get; set; }
        // public int Stats { get; set; }
    }
}
