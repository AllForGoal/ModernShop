
using Entity.Core.authentication;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Services.IContract
{
    public interface IAuthenticationService
    {
        Task<string> Register(userIdentity user, string password);
        Task<bool> AddUserRole(userIdentity user, string role);
        Task<List<Claim>> GetClaims(userIdentity userIdentity);
    }
}
