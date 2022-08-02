using Entity.Core.authentication;
using Microsoft.IdentityModel.Tokens;
using Services.IContract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using z_EcommerceSystem.DTO;
using z_EcommerceSystem.Helpers;

namespace z_EcommerceSystem.Services
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly Jwt _jwt;
        public JwtAuthenticationManager(IAuthenticationService authenticationService, Jwt jwt)
        {
            _authenticationService = authenticationService;
            _jwt = jwt;
        }
        public async Task<AuthDTO> Register(RegisterModel register)
        {
            userIdentity user = new userIdentity {
                UserName = register.Email,
                Email = register.Email,
                //FirstName = register.FirstName,
                //LastName = register.LastName
            };

            var res = await _authenticationService.Register(user, register.Password);
            if (res is not null)
                return new AuthDTO { Message = res };

            var jwtSecurityToken = await CreateJwtToken(user);

            return new AuthDTO
            {
                Message = "registeres successfuly",
                IsAuthenticated = true,
                UserName = register.FirstName + register.LastName,
                Email = register.Email,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                ExpiresOn =  jwtSecurityToken.ValidTo.Hour,
                Roles = new List<string> { "Member" }
            };
        }


        public async Task<JwtSecurityToken> CreateJwtToken(userIdentity userIdentity)
        {
            var claims = await _authenticationService.GetClaims(userIdentity);
           
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(_jwt.DurationInHours),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
