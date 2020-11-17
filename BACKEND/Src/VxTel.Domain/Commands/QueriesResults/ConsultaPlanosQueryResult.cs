using System;
using System.Collections.Generic;
using System.Text;

namespace VxTel.Domain.Commands.QueriesResults
{
    public class ConsultaPlanosQueryResult
    {
        /// <summary>
        /// Retorna o Id do Plano
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna o Nome do Plano
        /// </summary>
        public string NomePlano { get; set; }
        
        /// <summary>
        /// Retorna os minutos do plano
        /// </summary>
        public int MinutosPlano { get; set; }
    }
}
