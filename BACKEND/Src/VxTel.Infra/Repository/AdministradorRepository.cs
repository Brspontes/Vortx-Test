using Dapper;
using System.Threading.Tasks;
using VxTel.Domain.Entities;
using VxTel.Domain.Interfaces.Repository;
using VxTel.Infra.DataContext;
using VxTel.Shared.ProcsName;

namespace VxTel.Infra.Repository
{
    public class AdministradorRepository : IAdministradorRepository
    {
        private readonly SqlDataContext sqlDataContext;

        public AdministradorRepository(SqlDataContext sqlDataContext)
        {
            this.sqlDataContext = sqlDataContext;
        }

        public async Task<VxTelUser> Login(string user, string senha)
        {
            var retorno = await sqlDataContext.Connection.QueryFirstOrDefaultAsync<VxTelUser>
            (
                ProceduresNames.LOGIN,
                new { Login = user, Senha = senha },
                commandType: System.Data.CommandType.StoredProcedure
            );

            return retorno;
        }
    }
}
