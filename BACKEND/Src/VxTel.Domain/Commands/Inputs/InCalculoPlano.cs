using FluentValidator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VxTel.Shared.MessageValidators;

namespace VxTel.Domain.Commands.Inputs
{
    public class InCalculoPlano
    {
        public string Origem { get; set; }

        public string Destino { get; set; }

        public int MinutosDesejados { get; set; }

        public int MinutosPlano { get; set; }
    }
}
