using Entity.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class StockDto
    {
        public string Id { get; set; }
        public string Color { get; set; }
        public Enums.Size Size { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
    }
    public class StockUpdateDto
    {
        public string Id { get; set; }
        public string Color { get; set; }
        public Enums.Size Size { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
    }
}
