using System;
using System.Collections.Generic;
using System.Text;

namespace VxTel.Domain.Commands.QueriesResults
{
    public class ConsultaPrecoCalculoPlano
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public decimal CustoMin { get; set; }
    }
}
