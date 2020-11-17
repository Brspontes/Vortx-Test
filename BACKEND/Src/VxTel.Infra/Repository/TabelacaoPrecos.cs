using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Domain.Commands.Inputs;
using VxTel.Domain.Commands.QueriesResults;
using VxTel.Domain.Interfaces.Repository;
using VxTel.Infra.DataContext;
using VxTel.Shared.ProcsName;

namespace VxTel.Infra.Repository
{
    public class TabelacaoPrecos : ITabelacaoPrecos
    {
        private readonly SqlDataContext sqlDataContext;

        public TabelacaoPrecos(SqlDataContext sqlDataContext)
        {
            this.sqlDataContext = sqlDataContext;
        }

        public async Task<ConsultaPrecoCalculoPlano> ObterParaCalculoDePlano(InCalculoPlano inCalculoPlano) => await
            sqlDataContext.Connection.QueryFirstOrDefaultAsync<ConsultaPrecoCalculoPlano>
            (
                ProceduresNames.CONSULTAR_TABELACAO_PRECOS_CALCULO_PLANO,
                new { Origem = inCalculoPlano.Origem, Destino = inCalculoPlano.Destino },
                commandType: System.Data.CommandType.StoredProcedure
            );

        public async Task<IEnumerable<ConsultaTabelacaoPrecosQueryResult>> ObterTodos() => await
             sqlDataContext.Connection.QueryAsync<ConsultaTabelacaoPrecosQueryResult>
            (
                ProceduresNames.CONSULTAR_TABELACAO_PRECOS,
                new { },
                commandType: System.Data.CommandType.StoredProcedure
            );
    }
}
