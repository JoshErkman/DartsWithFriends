using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Models
{
    public class MatchRoundCreate
    {
        public int MatchId { get; set; }
        public int MatchSetupId { get; set; }
        public int PlayerOneNeededScore { get; set; }
        public int PlayerTwoNeededScore { get; set; }
        public int SetScore { get; set; }
        public int LegScore { get; set; }
        public int PlayerOneAvgRoundScore { get; set; }
        public int PlayerTwoAvgRoundScore { get; set; } 

        [Required]
        [Range(0, 180, ErrorMessage = "Total points must be between 0 and 180.")]
        public int TotalPoints { get; set; }

    }
}
