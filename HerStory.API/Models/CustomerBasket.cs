using System.ComponentModel.DataAnnotations;

namespace HerStory.API.Models
{
    public class CustomerBasket
    {
        [Required]
        public int BasketId { get; set; }
        [Required]
        public int UserSecret { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}