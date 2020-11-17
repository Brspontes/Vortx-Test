
using AutoMapper;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VxTel.Domain.Commands.Inputs;
using VxTel.Domain.Commands.Outputs;
using VxTel.Domain.Entities;
using VxTel.Domain.Interfaces.Application;
using VxTel.Domain.Interfaces.Repository;
using VxTel.Shared.MessageValidators;

namespace VxTel.Application.PlanosContext
{
    public class PlanosVxTellApplication : Notifiable, IPlanosVxTellApplication
    {
        private readonly IPlanosVxTelRepository planosVxTelRepository;
        private readonly IMapper mapper;

        public PlanosVxTellApplication(IPlanosVxTelRepository planosVxTelRepository, IMapper mapper)
        {
            this.planosVxTelRepository = planosVxTelRepository;
            this.mapper = mapper;
        }

        public async Task<OutPlanoCadastrado> NovoPlano(InNovoPlano novoPlano)
        {
            ValidarPlano(novoPlano);

            if (this.Invalid)
                return new OutPlanoCadastrado { Message = this.Notifications };

            var retorno = await planosVxTelRepository.AdicionarNovoPlano(mapper.Map<PlanosVxTel>(novoPlano));

            if (retorno is null)
                return new OutPlanoCadastrado { Message = Messages.ERRO_REGISTRAR_PLANO };

            var outPlano = mapper.Map<OutPlanoCadastrado>(retorno);
            outPlano.Message = "Sucesso";

            return outPlano;
        }

        private void ValidarPlano(InNovoPlano novoPlano)
        {
            AddNotifications(new FluentValidator.Validation.ValidationContract().Requires()
              .IsNotNullOrEmpty(novoPlano.NomePlano, "Nome Plano", Messages.NOME_PLANO_INCORRETO)
              .IsGreaterThan(novoPlano.MinutosPlano, 0, "Minutos", Messages.QUANTIDADE_MINUTOS_PLANO));
        }
    }
}
