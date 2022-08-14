using Entity.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Entity.Core.Models
{
    public class Stock : EntityId
    {
        //        public string Color { get; set; }
        public string Color { get; set; }
        public Enums.Size Size { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
    }
}