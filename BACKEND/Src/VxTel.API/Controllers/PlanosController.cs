using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.API.Services;
using VxTel.Domain.Commands.Inputs;
using VxTel.Domain.Commands.Outputs;
using VxTel.Domain.Interfaces.Application;
using VxTel.Domain.Interfaces.Repository;

namespace VxTel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanosController : ControllerBase
    {
        private readonly ICalculaPlano calculaPlano;
        private readonly IPlanosVxTelRepository planosVxTelRepository;
        private readonly ITabelacaoPrecos tabelacaoPrecos;
        private readonly IMapper mapper;
        private readonly IPlanosVxTellApplication planosVxTellApplication;
        private readonly TokenService tokenService;

        public PlanosController(IPlanosVxTelRepository planosVxTelRepository, IMapper mapper, ITabelacaoPrecos tabelacaoPrecos, ICalculaPlano calculaPlano, 
            TokenService tokenService, IPlanosVxTellApplication planosVxTellApplication)
        {
            this.planosVxTelRepository = planosVxTelRepository;
            this.mapper = mapper;
            this.tabelacaoPrecos = tabelacaoPrecos;
            this.calculaPlano = calculaPlano;
            this.tokenService = tokenService;
            this.planosVxTellApplication = planosVxTellApplication;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OutConsultaPlanos>>> ObterTodos() =>
           Ok(mapper.Map<IEnumerable<OutConsultaPlanos>>(await planosVxTelRepository.ConsultarTodosPlanos()));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<OutConsultaPlanos>> ObterPorId(int id) =>
            Ok(mapper.Map<OutConsultaPlanos>(await planosVxTelRepository.ConsultarPlanoPorId(id)));

        [HttpGet]
        [Route("TabelaPrecos")]
        public async Task<ActionResult<IEnumerable<OutConsultaTabelacaoPrecos>>> ObterTabelaDePrecos() =>
            Ok(mapper.Map<IEnumerable<OutConsultaTabelacaoPrecos>>(await tabelacaoPrecos.ObterTodos()));

        [HttpPost]
        [Route("CalculaValorMinutosPlano")]
        public async Task<ActionResult<OutPrecoCalculadoPlano>> CalculaValorMinutosPlano(InCalculoPlano inCalculoPlano) =>
            Ok(await calculaPlano.CalcularPlano(inCalculoPlano));

        [HttpPost]
        [Route("NovoPlano")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "administrador")]
        public async Task<ActionResult<OutPlanoCadastrado>> NovoPlano(InNovoPlano novoPlano)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var retorno = await planosVxTellApplication.NovoPlano(novoPlano);

            return Ok(retorno);
        }

        [HttpDelete]
        [Route("RemoverPlano")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "administrador")]
        public async Task<ActionResult<OutPlanoCadastrado>> RemoverPlano(int IdPlano)
        {
            var retorno = await planosVxTelRepository.Delete(IdPlano);

            return Ok(retorno);
        }

    }
}