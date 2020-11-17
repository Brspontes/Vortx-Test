using System.Threading.Tasks;
using VxTel.Domain.Entities;

namespace VxTel.Domain.Interfaces.Repository
{
    public interface IAdministradorRepository
    {
        Task<VxTelUser> Login(string user, string senha);
    }
}
