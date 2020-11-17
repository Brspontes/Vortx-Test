using System;
using System.Collections.Generic;
using System.Text;

namespace VxTel.Domain.Commands.Inputs
{
    public class InLogin
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public object Messages { get; set; }
    }
}
