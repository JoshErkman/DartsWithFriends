using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Models
{
    public class RoundEdit
    {
        [Required]
        public int RoundId { get; set; }

        [Required]
        [Range(0, 180, ErrorMessage = "Total points must be between 0 and 180.")]
        public int TotalPoints { get; set; }

        [Required]
        public int MatchId { get; set; }
    }
}
