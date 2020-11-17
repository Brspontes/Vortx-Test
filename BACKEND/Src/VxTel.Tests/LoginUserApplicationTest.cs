using Moq;
using NUnit.Framework;
using VxTel.Domain.Commands.Inputs;
using VxTel.Domain.Commands.Outputs;
using VxTel.Domain.Interfaces.Application;
using VxTel.Infra.DataContext;

namespace VxTel.Tests
{
    public class LoginUserApplicationTest
    {
        private Mock<Microsoft.Extensions.Configuration.IConfiguration> Configuration;
        private OutLogin outLoginResultadoEsperado = new OutLogin { Login = "admin", Permissoes = "administrador", Message = "Sucesso" };

        [SetUp]
        public void Setup()
        {
            Configuration = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
        }

        [Test]
        public void AdicionarNovoPlanoTestsQuandoRetornoNullTest()
        {
            var mock = new Mock<ILoginUser>();
            var Configracao = new Mock<SqlDataContext>(Configuration.Object);

            mock.Setup(c => c.Login(It.IsAny<InLogin>())).ReturnsAsync(outLoginResultadoEsperado);
            var retorno = mock.Object.Login(new InLogin { Usuario = "admin", Senha = "admin" });

            Assert.AreEqual(outLoginResultadoEsperado, retorno.Result);
        }
    }
}
