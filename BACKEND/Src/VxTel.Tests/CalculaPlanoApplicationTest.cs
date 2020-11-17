using Moq;
using NUnit.Framework;
using VxTel.Domain.Commands.Inputs;
using VxTel.Domain.Commands.Outputs;
using VxTel.Domain.Interfaces.Application;
using VxTel.Infra.DataContext;
using VxTel.Shared.MessageValidators;

namespace VxTel.Tests
{
    public class CalculaPlanoApplicationTest
    {
        private Mock<Microsoft.Extensions.Configuration.IConfiguration> Configuration;
        private OutPrecoCalculadoPlano OutPrecoCalculadoPlanoEntradaInvalida = new OutPrecoCalculadoPlano { Message = Messages.MINUTOS_MAIOR_QUE_ZERO };
        private OutPrecoCalculadoPlano OutPrecoCalculadoPlanoDDDOrigemDestino = new OutPrecoCalculadoPlano { Message = Messages.DDD_ORIGEM_DESTINO_IGUAIS };
        private OutPrecoCalculadoPlano OutPrecoCalculadoPlanoQuandoSucesso = new OutPrecoCalculadoPlano { Message = "Sucesso", PrecoCalculadoPlano = 100, PrecoCalculadoSemPlano = 255 };

        [SetUp]
        public void Setup()
        {
            Configuration = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
        }

        [Test]
        public void CalculaPlanoEntradaInvalidaTest()
        {
            var mock = new Mock<ICalculaPlano>();
            var Configracao = new Mock<SqlDataContext>(Configuration.Object);

            mock.Setup(c => c.CalcularPlano(It.IsAny<InCalculoPlano>())).ReturnsAsync(OutPrecoCalculadoPlanoEntradaInvalida);
            var retorno = mock.Object.CalcularPlano(new InCalculoPlano { Destino = "01", MinutosDesejados = 10, Origem = "01" });

            Assert.AreEqual(OutPrecoCalculadoPlanoEntradaInvalida.Message.ToString(), retorno.Result.Message.ToString());
        }

        [Test]
        public void CalculaPlanoDDDOrigemDestinoIguaisTest()
        {
            var mock = new Mock<ICalculaPlano>();
            var Configracao = new Mock<SqlDataContext>(Configuration.Object);

            mock.Setup(c => c.CalcularPlano(It.IsAny<InCalculoPlano>())).ReturnsAsync(OutPrecoCalculadoPlanoDDDOrigemDestino);
            var retorno = mock.Object.CalcularPlano(new InCalculoPlano { Destino = "01", MinutosDesejados = 10, Origem = "01" });

            Assert.AreEqual(OutPrecoCalculadoPlanoDDDOrigemDestino.Message.ToString(), retorno.Result.Message.ToString());
        }

        [Test]
        public void CalculaPlanoQuandoSucesso()
        {
            var mock = new Mock<ICalculaPlano>();
            var Configracao = new Mock<SqlDataContext>(Configuration.Object);

            mock.Setup(c => c.CalcularPlano(It.IsAny<InCalculoPlano>())).ReturnsAsync(OutPrecoCalculadoPlanoQuandoSucesso);
            var retorno = mock.Object.CalcularPlano(new InCalculoPlano { Destino = "011", MinutosDesejados = 200, Origem = "017" });

            Assert.AreEqual(OutPrecoCalculadoPlanoQuandoSucesso.Message.ToString(), retorno.Result.Message.ToString());
            Assert.AreEqual(OutPrecoCalculadoPlanoQuandoSucesso.PrecoCalculadoPlano, retorno.Result.PrecoCalculadoPlano);
        }
    }
}
