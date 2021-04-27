using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Models.MatchSetup
{
    public class MatchSetupCreate
    { 
        [Required]
        public string OpponentEmail { get; set; }
        [Required]
        [Range(0,5, ErrorMessage = "Sets must be between 0 and 5.")]
        public int NumberOfSets { get; set; }
        [Required]
        [Range(1,5, ErrorMessage = "Legs must be between 1 and 5.")]
        public int NumberOfLegs { get; set; }
    }


}
