using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace z_EcommerceSystem.DTO
{
    public class AuthDTO
    {
        public string Message { set; get; }
        public bool IsAuthenticated { set; get; }
        public string UserName { set; get; }
        public string Email { set; get; }
        public List<string> Roles { set; get; }
        public string Token { set; get; }
        public double ExpiresOn { set; get; }
    }
}
