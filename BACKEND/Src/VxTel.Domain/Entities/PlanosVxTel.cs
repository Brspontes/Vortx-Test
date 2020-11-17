using FluentValidator;
using VxTel.Shared.MessageValidators;

namespace VxTel.Domain.Entities
{
    public class PlanosVxTel : Notifiable
    {
        public PlanosVxTel(int id, string nomePlano, int minutosPlano)
        {
            Id = id;
            NomePlano = nomePlano;
            MinutosPlano = minutosPlano;

            AddNotifications(new FluentValidator.Validation.ValidationContract().Requires()

               .HasMinLen(NomePlano, 1, "Nome do Plano", Messages.TAMANHO_MINIMO_NOME_PLANO)
               .HasMaxLen(NomePlano, 50, "Nome do Plano", Messages.TAMANHO_MAXIMO_NOME_PLANO)
               .IsNullOrEmpty(NomePlano, "Nome do Plano", Messages.NAO_NULO_NOME_PLANO)
               
               .IsGreaterThan(MinutosPlano, 0, "Minutos do plano", Messages.MINUTOS_MAIOR_QUE_ZERO));
        }

        public int Id { get; private set; }
        public string NomePlano { get; private set; }
        public int MinutosPlano { get; private set; }
    }
}
