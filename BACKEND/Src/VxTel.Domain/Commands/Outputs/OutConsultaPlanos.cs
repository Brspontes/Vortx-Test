using System;
using System.Collections.Generic;
using System.Text;

namespace VxTel.Domain.Commands.Outputs
{
    public class OutConsultaPlanos
    {
        public int Id { get; private set; }
        public string NomePlano { get; private set; }
        public int MinutosPlano { get; private set; }
    }
}
