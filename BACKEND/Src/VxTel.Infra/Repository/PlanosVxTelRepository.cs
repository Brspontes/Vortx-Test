using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Domain.Commands.QueriesResults;
using VxTel.Domain.Entities;
using VxTel.Domain.Interfaces.Repository;
using VxTel.Infra.DataContext;
using VxTel.Shared.MessageValidators;
using VxTel.Shared.ProcsName;

namespace VxTel.Infra.Repository
{
    public class PlanosVxTelRepository : IPlanosVxTelRepository
    {
        private readonly SqlDataContext sqlDataContext;

        public PlanosVxTelRepository(SqlDataContext sqlDataContext)
        {
            this.sqlDataContext = sqlDataContext;
        }

        public async Task<PlanosVxTel> AdicionarNovoPlano(PlanosVxTel plano)
        {
            var p = new DynamicParameters();
            p.Add("@NOMEPLANO", plano.NomePlano);
            p.Add("@MINUTOS", plano.MinutosPlano);
            p.Add("@OUTPUT", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

            var retorno = await
                sqlDataContext.Connection.ExecuteAsync
                (
                ProceduresNames.NOVO_PLANO,
                p,
                commandType: System.Data.CommandType.StoredProcedure
                );

            if (retorno > 0)
                return new PlanosVxTel(p.Get<int>("@OUTPUT"), plano.NomePlano, plano.MinutosPlano);

            return null;
        }

        public async Task<ConsultaPlanosQueryResult> ConsultarPlanoPorId(int pIdPlano) => await
             sqlDataContext.Connection.QueryFirstOrDefaultAsync<ConsultaPlanosQueryResult>
            (
                ProceduresNames.CONSULTAR_PLANOS_POR_ID,
                new { Id = pIdPlano },
                commandType: System.Data.CommandType.StoredProcedure
            );

        public async Task<IEnumerable<ConsultaPlanosQueryResult>> ConsultarTodosPlanos() => await
            sqlDataContext.Connection.QueryAsync<ConsultaPlanosQueryResult>
            (
                ProceduresNames.CONSULTAR_PLANOS,
                new { },
                commandType: System.Data.CommandType.StoredProcedure
            );

        public async Task<string> Delete(int idPlano)
        {
            var retorno = await ConsultarPlanoPorId(idPlano);

            if (retorno is null)
                return Messages.REGISTRO_NAO_ECONTRADO;

            sqlDataContext.Connection.Execute
            (
                ProceduresNames.DELETE_PLANO,
                new { Id = idPlano },
                commandType: System.Data.CommandType.StoredProcedure
            );

            return Messages.OPERACAO_REALIZADA_COM_SUCESSO;
        }
    }
}
