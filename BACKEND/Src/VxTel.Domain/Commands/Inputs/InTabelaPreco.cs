using System;
using System.Collections.Generic;
using System.Text;

namespace VxTel.Domain.Commands.Inputs
{
    public class InTabelaPreco
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public decimal CustoMin { get; set; }
    }
}
