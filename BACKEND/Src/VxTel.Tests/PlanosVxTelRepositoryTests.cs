using Moq;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using VxTel.Domain.Commands.QueriesResults;
using VxTel.Domain.Entities;
using VxTel.Domain.Interfaces.Repository;
using VxTel.Infra.DataContext;

namespace VxTel.Tests
{
    public class PlanosVxTelRepositoryTests
    {
        private Mock<Microsoft.Extensions.Configuration.IConfiguration> Configuration;
        private PlanosVxTel AdicionarNovosPlanosTestResultadoEsperado;
        private PlanosVxTel AdicionarNovosPlanosTestResultadoEsperadoRetornoNull = null;
        private ConsultaPlanosQueryResult ConsultaPlanosQueryResultResultadoEsperado = new ConsultaPlanosQueryResult { Id = 1, MinutosPlano = 10, NomePlano = "Teste 5000" };
        private IEnumerable<ConsultaPlanosQueryResult> ConsultaTodosPlanosQueryResultResultadoEsperado;

        [SetUp]
        public void Setup()
        {
            Configuration = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
            AdicionarNovosPlanosTestResultadoEsperado = new PlanosVxTel(0, "PlanoTeste 5000", 50);
        }

        [Test]
        public void AdicionarNovoPlanoTests()
        {
            var mock = new Mock<IPlanosVxTelRepository>();
            var Configracao = new Mock<SqlDataContext>(Configuration.Object);

            mock.Setup(c => c.AdicionarNovoPlano(It.IsAny<PlanosVxTel>())).ReturnsAsync(AdicionarNovosPlanosTestResultadoEsperado);
            var retorno = mock.Object.AdicionarNovoPlano(AdicionarNovosPlanosTestResultadoEsperado);

            Assert.AreEqual(AdicionarNovosPlanosTestResultadoEsperado, retorno.Result);
        }

        [Test]
        public void AdicionarNovoPlanoTestsQuandoRetornoNullTest()
        {
            var mock = new Mock<IPlanosVxTelRepository>();
            var Configracao = new Mock<SqlDataContext>(Configuration.Object);

            mock.Setup(c => c.AdicionarNovoPlano(It.IsAny<PlanosVxTel>())).ReturnsAsync(AdicionarNovosPlanosTestResultadoEsperadoRetornoNull);
            var retorno = mock.Object.AdicionarNovoPlano(AdicionarNovosPlanosTestResultadoEsperado);

            Assert.IsNull(retorno.Result);
        }

        [Test]
        public void ConsultarPlanosPorIdTest()
        {
            var mock = new Mock<IPlanosVxTelRepository>();
            var Configracao = new Mock<SqlDataContext>(Configuration.Object);

            mock.Setup(c => c.ConsultarPlanoPorId(It.IsAny<int>())).ReturnsAsync(ConsultaPlanosQueryResultResultadoEsperado);
            var retorno = mock.Object.ConsultarPlanoPorId(0);

            Assert.AreEqual(ConsultaPlanosQueryResultResultadoEsperado, retorno.Result);
        }

        [Test]
        public void ConsultarPlanosTest()
        {
            ConsultaTodosPlanosQueryResultResultadoEsperado = new List<ConsultaPlanosQueryResult>
            {
                new ConsultaPlanosQueryResult { Id = 1, MinutosPlano = 10, NomePlano = "Teste 5000" }
            };

            var mock = new Mock<IPlanosVxTelRepository>();
            var Configracao = new Mock<SqlDataContext>(Configuration.Object);

            mock.Setup(c => c.ConsultarTodosPlanos()).ReturnsAsync(ConsultaTodosPlanosQueryResultResultadoEsperado);
            var retorno = mock.Object.ConsultarTodosPlanos();

            Assert.AreEqual(ConsultaTodosPlanosQueryResultResultadoEsperado, retorno.Result);
        }
    }
}
