using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HerStory.Core.Entities
{
    public class BasketItem : BaseEntity
    {
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Basket")] 
        public int BasketId { get; set; }
        
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}