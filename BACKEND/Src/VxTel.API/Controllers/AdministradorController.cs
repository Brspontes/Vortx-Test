using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VxTel.API.Services;
using VxTel.Domain.Commands.Inputs;
using VxTel.Domain.Commands.Outputs;
using VxTel.Domain.Interfaces.Application;

namespace VxTel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly ILoginUser loginUser;
        private readonly TokenService tokenService;

        public AdministradorController(ILoginUser loginUser, TokenService tokenService)
        {
            this.loginUser = loginUser;
            this.tokenService = tokenService;
        }

        [HttpPost]
        public async Task<ActionResult<OutLogin>> Login(InLogin login)
        {
            var realizarLogin = await loginUser.Login(login);

            if (realizarLogin.Message != null)
                return BadRequest(realizarLogin);

            realizarLogin.Token = tokenService.GenerateToken(realizarLogin);

            return realizarLogin;
        }
    }
}