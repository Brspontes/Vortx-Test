using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VxTel.Domain.Commands.Inputs;
using VxTel.Domain.Commands.Outputs;

namespace VxTel.Domain.Interfaces.Application
{
    public interface IPlanosVxTellApplication
    {
        Task<OutPlanoCadastrado> NovoPlano(InNovoPlano novoPlano);
    }
}
