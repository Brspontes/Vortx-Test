using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using VxTel.Domain.Commands.Inputs;
using VxTel.Domain.Commands.QueriesResults;
using VxTel.Domain.Interfaces.Repository;
using VxTel.Infra.DataContext;

namespace VxTel.Tests
{
    public class TabelacaoPrecosRepositoryTests
    {
        private Mock<Microsoft.Extensions.Configuration.IConfiguration> Configuration;
        private ConsultaPrecoCalculoPlano resultadoEsperado = new ConsultaPrecoCalculoPlano { CustoMin = 10, Destino = "011", Origem = "017" };
        private IEnumerable<ConsultaTabelacaoPrecosQueryResult> ConsultaTabelacaoResultadoEsperado; 

        [SetUp]
        public void Setup()
        {
            Configuration = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
        }

        [Test]
        public void ObterParaCalculoDePlanoTest()
        {
            var ITabelacaoPrecoMock = new Mock<ITabelacaoPrecos>();
            var Configracao = new Mock<SqlDataContext>(Configuration.Object);

            ITabelacaoPrecoMock.Setup(c => c.ObterParaCalculoDePlano(It.IsAny<InCalculoPlano>()))
                .ReturnsAsync(resultadoEsperado);

            var retorno = ITabelacaoPrecoMock.Object.ObterParaCalculoDePlano(new InCalculoPlano
            {
                Origem = "011",
                Destino = "017"
            });

            Assert.AreEqual(resultadoEsperado, retorno.Result);
        }

        [Test]
        public void ConsultaTabelacaoPrecosTest()
        {
            ConsultaTabelacaoResultadoEsperado = new List<ConsultaTabelacaoPrecosQueryResult>
            {
                new ConsultaTabelacaoPrecosQueryResult
                {
                    CustoMin = 10,
                    Destino = "011",
                    Origem = "017",
                    Id = 1
                }
            };

            var ITabelacaoPrecoMock = new Mock<ITabelacaoPrecos>();
            var Configracao = new Mock<SqlDataContext>(Configuration.Object);

            ITabelacaoPrecoMock.Setup(c => c.ObterTodos())
                .ReturnsAsync(ConsultaTabelacaoResultadoEsperado);

            var retorno = ITabelacaoPrecoMock.Object.ObterTodos();

            Assert.AreEqual(ConsultaTabelacaoResultadoEsperado, retorno.Result);
        }
    }
}