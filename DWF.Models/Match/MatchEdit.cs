using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Models.Match
{
    public class MatchEdit
    {
        public int MatchId { get; set; }
        public int PlayerOneNeededScore { get; set; }
        public int PlayerTwoNeededScore { get; set; }
        public int PlayerOneAvgRoundScore { get; set; }
        public int PlayerTwoAvgRoundScore { get; set; }

        [Range(0,180, ErrorMessage = "Score must be between 0 and 180.")]
        public int PlayerOneRoundScore { get; set; }

        [Range(0, 180, ErrorMessage = "Score must be between 0 and 180.")]
        public int PlayerTwoRoundScore { get; set; }
        public int Rounds { get; set; }
    }
}
