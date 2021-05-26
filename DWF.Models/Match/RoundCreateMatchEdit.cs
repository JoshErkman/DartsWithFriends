using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Models.Match
{
    public class RoundCreateMatchEdit
    {
        public int MatchId { get; set; }

        [Range(0,501, ErrorMessage = "Needed score can not go below 0.")]
        public int PlayerOneNeededScore { get; set; }

        [Range(0, 501, ErrorMessage = "Needed score can not go below 0.")]
        public int PlayerTwoNeededScore { get; set; }

        public int PlayerOneAvgRoundScore { get; set; }

        public int PlayerTwoAvgRoundScore { get; set; }

        [Range(0,180, ErrorMessage = "Score must be between 0 and 180.")]
        public int PlayerOneRoundScore { get; set; }

        [Range(0, 180, ErrorMessage = "Score must be between 0 and 180.")]
        public int PlayerTwoRoundScore { get; set; }

        public int Rounds { get; set; }

        public int RoundId { get; set; }

        public int TotoalRoundPoints { get; set; }

        public int PlayerOneTotalMatchPoints { get; set; }

        public int PlayerTwoTotalMatchPoints { get; set; }

        public bool IsTurn { get; set; }
    }
}
