using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace z_EcommerceSystem.Helpers
{
    public  class Jwt
    {
        public  string Key { set; get; }
        public string Issuer { set; get; }
        public string Audience { set; get; }
        public double DurationInHours { set; get; }
    }
}
