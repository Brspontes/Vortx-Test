using System;
using System.Collections.Generic;
using System.Text;

namespace VxTel.Domain.Commands.Inputs
{
    public class InPlanoSelecionado
    {
        public int Id { get; set; }
        public string NomePlano { get; set; }
        public int MinutosPlano { get; set; }
    }
}
