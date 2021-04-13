using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Data
{
    public class Player
    {
        public int PlayerId { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       //public List<Match> Matches { get; set; }
       //public List<Stats> Statistics { get; set; }
        public int FiveOOne_AvgBest { get; set; }
        public int FiveOOne_AvgWorst { get; set; }
        public int CheckOutBest { get; set; }
        public int CheckOutWorst { get; set; }

    }
}
