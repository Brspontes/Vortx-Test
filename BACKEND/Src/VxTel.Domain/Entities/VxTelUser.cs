using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace VxTel.Domain.Entities
{
    public class VxTelUser
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }
    }
}
