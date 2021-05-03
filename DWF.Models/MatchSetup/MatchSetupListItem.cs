using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Models.MatchSetup
{
    public class MatchSetupListItem
    {
        public int MatchSetupId { get; set; }
        public string PlayerOneEmail { get; set; }
        public string PlayerTwoEmail { get; set; }
        [UIHint("Starred")]
        public bool PlayerOneIsStarred { get; set; }
        [UIHint("Starred")]
        public bool PlayerTwoIsStarred { get; set; }
    }
}
