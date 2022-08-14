using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }
        public int BrandId { get; set; }
        public ICollection<StockDto> Items { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
    }
     public class ProductAddDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public double Rate { get; set; }
        public int BrandId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
