using AutoMapper;
using FluentValidator;
using System.Threading.Tasks;
using VxTel.Domain.Commands.Inputs;
using VxTel.Domain.Commands.Outputs;
using VxTel.Domain.Interfaces.Application;
using VxTel.Domain.Interfaces.Repository;
using VxTel.Shared.MessageValidators;

namespace VxTel.Application.PlanosContext.Administrador
{
    public class LoginUser : Notifiable, ILoginUser
    {
        private readonly IAdministradorRepository administradorRepository;
        private readonly IMapper mapper;

        public LoginUser(IAdministradorRepository administradorRepository, IMapper mapper)
        {
            this.administradorRepository = administradorRepository;
            this.mapper = mapper;
        }

        public async Task<OutLogin> Login(InLogin user)
        {
            ValidarLogin(user);

            if (this.Invalid)
                return new OutLogin { Message = this.Notifications };

            var consultarLogin = await administradorRepository.Login(user.Usuario, user.Senha);

            if (consultarLogin is null)
                return new OutLogin { Message = Messages.LOGIN_OU_SENHA_INCORRETOS };

            return mapper.Map<OutLogin>(consultarLogin);
        }

        private void ValidarLogin(InLogin user)
        {
            AddNotifications(new FluentValidator.Validation.ValidationContract().Requires()
              .IsNotNullOrEmpty(user.Usuario, "Login ou Senha", Messages.LOGIN_OU_SENHA_INCORRETOS)
              .IsNotNullOrEmpty(user.Senha, "Login ou Senha", Messages.LOGIN_OU_SENHA_INCORRETOS));
        }
    }
}
