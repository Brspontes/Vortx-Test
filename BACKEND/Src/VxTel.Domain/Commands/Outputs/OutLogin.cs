using System;
using System.Collections.Generic;
using System.Text;

namespace VxTel.Domain.Commands.Outputs
{
    public class OutLogin
    {
        public string Login { get; set; }
        public string Token { get; set; }
        public string Permissoes { get; set; }
        public object Message { get; set; }
    }
}
