using VxTel.Domain.Commands.QueriesResults;

namespace VxTel.Domain.Commands.Outputs
{
    public class OutPrecoCalculadoPlano
    {
        public decimal PrecoCalculadoPlano { get; set; }
        public decimal PrecoCalculadoSemPlano { get; set; }
        public object Message { get; set; }
    }
}
