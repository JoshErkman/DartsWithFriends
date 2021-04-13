using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Data
{
    public class MatchSetup
    {
        public int MatchSetupId { get; set; }

        [ForeignKey (nameof(Player))]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public int NumberOfSets { get; set; }
        public int NumberOfLegs { get; set; }
    }
}
