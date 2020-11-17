using System.Threading.Tasks;
using VxTel.Domain.Commands.Inputs;
using VxTel.Domain.Commands.Outputs;

namespace VxTel.Domain.Interfaces.Application
{
    public interface ICalculaPlano
    {
        Task<OutPrecoCalculadoPlano> CalcularPlano(InCalculoPlano inCalculoPlano);
    }
}
