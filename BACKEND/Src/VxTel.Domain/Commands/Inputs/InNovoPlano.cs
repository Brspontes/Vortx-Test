using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VxTel.Domain.Commands.Inputs
{
    public class InNovoPlano
    {
        [Required]
        public string NomePlano { get; set; }
        
        [Required]
        public int MinutosPlano { get; set; }
    }
}
