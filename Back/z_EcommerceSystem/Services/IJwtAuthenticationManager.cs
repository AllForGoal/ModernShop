using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using z_EcommerceSystem.DTO;

namespace z_EcommerceSystem.Services
{
    public interface IJwtAuthenticationManager
    {
        Task<AuthDTO> Register(RegisterModel register);
    }
}
