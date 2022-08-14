using Entity.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Core.Models
{
    public class ProductImage:EntityId
    {
        public string ImgagePath { get; set; }
        public int StockId { get; set; }
        [ForeignKey("StockId")]
        public Stock Stock { get; set; }
        public bool IsDefaultImag { get; set; }
    }
}