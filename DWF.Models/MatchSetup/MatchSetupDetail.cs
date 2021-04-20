using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Models.MatchSetup
{
    public class MatchSetupDetail
    {
        public int MatchSetupId { get; set; }
        public string PlayerOneId { get; set; }
        public string PlayerTwoId { get; set; }
        public int NumberOfSets { get; set; }
        public int NumberOfLegs { get; set; }
    }
}
