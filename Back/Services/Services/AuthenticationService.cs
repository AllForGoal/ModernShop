using Entity.Core.authentication;
using Microsoft.AspNetCore.Identity;
using Services.IContract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<userIdentity> _userManager;
        public AuthenticationService(UserManager<userIdentity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> AddUserRole(userIdentity user, string role)
        {
           var res = await _userManager.AddToRoleAsync(user, role);
            return res.Succeeded;
        }

        public async Task<string> Register(userIdentity user, string password)
        {
            string Message = null;
            if (await _userManager.FindByEmailAsync(user.Email) is not null)
            {
                Message = "Email Already registered !";
                return Message;
            }


            var res = await _userManager.CreateAsync(user, password);
            
            if (!res.Succeeded)
            {
                Message = String.Join(",", res.Errors.Select(s => s.Description));
                return Message;
            }

            await AddUserRole(user, "Member");
            return Message;
        }

        public async Task<List<Claim>> GetClaims(userIdentity userIdentity)
        {
            var userClaims = await _userManager.GetClaimsAsync(userIdentity);
            var roles = await _userManager.GetRolesAsync(userIdentity);
            var roleClaims = new List<Claim>();
            
            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userIdentity.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, userIdentity.Email),
                new Claim("uid", userIdentity.Id.ToString())
            }
            .Union(userClaims)
            .Union(roleClaims);


            return roleClaims;
        }
    }
}
