using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Data
{
    public class MatchSetup
    {
        public int MatchSetupId { get; set; }

       [ForeignKey (nameof(UserOne))]
        public string PlayerOneId { get; set; }
       public virtual ApplicationUser UserOne { get; set; }


        [ForeignKey(nameof(UserTwo))]
        public string PlayerTwoId { get; set; }
        public virtual ApplicationUser UserTwo { get; set; }

        [DefaultValue(false)]
        public bool PlayerOneIsStarred { get; set; }

        [DefaultValue(false)]
        public bool PlayerTwoIsStarred { get; set; }

    }
}
