using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace nDeath.Models
{
    public class Parabola
    {
        [Required(ErrorMessage = "Enter the coefficient A")]
        public int A{ get; set; }

        [Required (ErrorMessage = "Enter the coefficient B")]
        public int B { get; set; }

        [Required(ErrorMessage = "Enter the coefficient C")]
        public int C { get; set; }

        [Required(ErrorMessage = "Enter step")]
        public int Step { get; set; }
        
        [Required(ErrorMessage = "Enter X1")]
        public int X1 { get; set; }

        [Required(ErrorMessage = "Enter X2")]
        public int X2 { get; set; }
    }
}