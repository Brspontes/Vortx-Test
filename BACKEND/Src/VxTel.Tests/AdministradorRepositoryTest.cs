using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using VxTel.Domain.Entities;
using VxTel.Domain.Interfaces.Repository;
using VxTel.Infra.DataContext;

namespace VxTel.Tests
{
    public class AdministradorRepositoryTest
    {
        private Mock<Microsoft.Extensions.Configuration.IConfiguration> Configuration;
        private VxTelUser User = new VxTelUser { Perfil = "administrador", Senha = "minhasenhasupersecreta", Usuario = "admin" };

        [SetUp]
        public void Setup()
        {
            Configuration = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
        }

        [Test]
        public void LoginTest()
        {
            var administradorRepository = new Mock<IAdministradorRepository>();
            var Configracao = new Mock<SqlDataContext>(Configuration.Object);

            administradorRepository.Setup(c => c.Login("admin", "minhasenhasupersecreta"))
                .ReturnsAsync(User);

            var retorno = administradorRepository.Object.Login("admin", "minhasenhasupersecreta");
            Assert.AreEqual(User, retorno.Result);
        }
    }
}
