using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace z_EcommerceSystem.DTO
{
    public class RegisterModel
    {
        [Required, StringLength(50)]
        public string FirstName { set; get; }
        [Required, StringLength(50)]
        public string LastName { set; get; }
        [Required]
        public string Email { set; get; }
        [Required]
        public string Password { set; get; }
    }
}
