﻿using System;
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
        public int NumberOfSets { get; set; }
        [Required]
        public int NumberOfLegs { get; set; }
    }


}
