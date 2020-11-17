using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VxTel.Domain.Commands.QueriesResults;
using VxTel.Domain.Entities;

namespace VxTel.Domain.Interfaces.Repository
{
    public interface IPlanosVxTelRepository
    {
        Task<IEnumerable<ConsultaPlanosQueryResult>>  ConsultarTodosPlanos();
        Task<ConsultaPlanosQueryResult> ConsultarPlanoPorId(int pIdPlano);
        Task<PlanosVxTel> AdicionarNovoPlano(PlanosVxTel plano);
        Task<string> Delete(int idPlano);
    }
}
