using FluentValidator;
using System.Threading.Tasks;
using VxTel.Domain.Commands.Inputs;
using VxTel.Domain.Commands.Outputs;
using VxTel.Domain.Interfaces.Application;
using VxTel.Domain.Interfaces.Repository;
using VxTel.Shared.MessageValidators;

namespace VxTel.Application.PlanosContext.CalculoPlanos
{
    public class CalculaPlano : Notifiable, ICalculaPlano
    {
        private readonly ITabelacaoPrecos tabelacaoPrecos;

        public CalculaPlano(ITabelacaoPrecos tabelacaoPrecos)
        {
            this.tabelacaoPrecos = tabelacaoPrecos;
        }

        public async Task<OutPrecoCalculadoPlano> CalcularPlano(InCalculoPlano inCalculoPlano)
        {
            ValidaEntrada(inCalculoPlano);

            if (this.Invalid)
                return new OutPrecoCalculadoPlano { Message = this.Notifications };

            if (inCalculoPlano.Origem.Equals(inCalculoPlano.Destino))
                return new OutPrecoCalculadoPlano { Message = Messages.DDD_ORIGEM_DESTINO_IGUAIS };

            var consultaCustoPlano = await tabelacaoPrecos.ObterParaCalculoDePlano(inCalculoPlano);

            if (consultaCustoPlano is null)
                return new OutPrecoCalculadoPlano { Message = Messages.NAO_FORAM_ENCONTRADOS_PLANOS };

            return new OutPrecoCalculadoPlano
            {
                Message = "Sucesso",
                PrecoCalculadoPlano = inCalculoPlano.MinutosDesejados > inCalculoPlano.MinutosPlano ?
                    PrecoCalculadoPlano(inCalculoPlano.MinutosPlano, inCalculoPlano.MinutosDesejados, consultaCustoPlano.CustoMin) : 0.0M,
                PrecoCalculadoSemPlano = PrecoCalculadoSemPlano(inCalculoPlano.MinutosDesejados, consultaCustoPlano.CustoMin)
            };
        }

        private decimal PrecoCalculadoPlano(int minutosPlano, int minutosDesejados, decimal custo) =>
             (((minutosDesejados - minutosPlano) * custo) + ((((minutosDesejados - minutosPlano) * custo) * 10) / 100));

        private decimal PrecoCalculadoSemPlano(int minutosDesejados, decimal custo) => (minutosDesejados * custo);

        private void ValidaEntrada(InCalculoPlano inCalculoPlano)
        {
            AddNotifications(new FluentValidator.Validation.ValidationContract().Requires()
                .HasLen(inCalculoPlano.Origem, 3, "Origem", Messages.TAMANHO_DDD_ORIGEM)
                .HasLen(inCalculoPlano.Destino, 3, "Destino", Messages.TAMANHO_DDD_DESTINO)
                .IsGreaterOrEqualsThan(inCalculoPlano.MinutosDesejados, 0, "Minutos Desejados", Messages.MINUTOS_MAIOR_QUE_ZERO));
        }
    }
}
