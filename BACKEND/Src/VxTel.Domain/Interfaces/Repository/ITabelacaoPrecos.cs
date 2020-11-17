using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VxTel.Domain.Commands.Inputs;
using VxTel.Domain.Commands.QueriesResults;

namespace VxTel.Domain.Interfaces.Repository
{
    public interface ITabelacaoPrecos
    {
        Task<IEnumerable<ConsultaTabelacaoPrecosQueryResult>> ObterTodos();
        Task<ConsultaPrecoCalculoPlano> ObterParaCalculoDePlano(InCalculoPlano inCalculoPlano);
    }
}
