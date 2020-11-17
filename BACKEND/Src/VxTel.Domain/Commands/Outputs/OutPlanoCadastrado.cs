using System;
using System.Collections.Generic;
using System.Text;

namespace VxTel.Domain.Commands.Outputs
{
    public class OutPlanoCadastrado
    {
        public int Id { get; private set; }
        public string NomePlano { get; private set; }
        public int MinutosPlano { get; private set; }
        public object Message { get; set; }
    }
}
