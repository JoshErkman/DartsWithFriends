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

       [ForeignKey (nameof(User))]
        public string PlayerId { get; set; }
       public virtual ApplicationUser User { get; set; }

        public int NumberOfSets { get; set; }
        public int NumberOfLegs { get; set; }
    }
}
