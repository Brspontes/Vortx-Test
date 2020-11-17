using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;
using VxTel.Shared.MessageValidators;

namespace VxTel.Domain.Entities
{
    public class TabelacaoPreco : Notifiable
    {
        public TabelacaoPreco(int id, string origem, string destino, decimal custoMin)
        {
            Id = id;
            Origem = origem;
            Destino = destino;
            CustoMin = custoMin;

            AddNotifications(new FluentValidator.Validation.ValidationContract().Requires()
                
                .HasLen(Origem, 3, "Origem", Messages.TAMANHO_DDD_ORIGEM)
                .IsNullOrEmpty(Origem, "Origem", Messages.NAO_NULO_ORIGEM)
                
                .HasLen(Destino, 3, "Destino", Messages.TAMANHO_DDD_DESTINO)
                .IsNullOrEmpty(Destino, "Destino", Messages.NAO_NULO_DESTINO)
                
                .IsGreaterThan(CustoMin, 0, "Custo por Minuto", Messages.CUSTO_MAIOR_QUE_ZERO));
        }

        public int Id { get; private set; }
        public string Origem { get; private set; }
        public string Destino { get; private set; }
        public decimal CustoMin { get; private set; }

    }
}
