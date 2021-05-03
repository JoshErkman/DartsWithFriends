using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Data
{
    public class Round
    {
        public int RoundId { get; set; }

        public int TotalRoundPoints { get; set; }

        [ForeignKey (nameof(Match))]
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
    }
}
