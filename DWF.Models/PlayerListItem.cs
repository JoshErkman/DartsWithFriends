using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Models
{
    public class PlayerListItem
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "501 Best Average")]
        public int FiveOOne_AvgBest { get; set; }
    }
}
