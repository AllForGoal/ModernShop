using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace z_EcommerceSystem.DTO
{
    public class CreateCategoryDTO
    {
        [Required]
        public string Name { get; set; }
        public int? ParentId { get; set; }

    }
}
