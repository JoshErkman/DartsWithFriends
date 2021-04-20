using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Models
{
    public class RoundCreate
    {
        [Required]
        public int TotalPoints { get; set; }

        public int MatchId { get; set; }
    }
}
