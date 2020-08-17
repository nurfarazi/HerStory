using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HerStory.Core.Entities.OrderAggregate;

namespace HerStory.Core.Entities
{
    public class CouponedOrder : BaseEntity
    {
        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; } 
        public Order Order { get; set; }
        
        [Required]
        [ForeignKey("Coupon")]
        public int CouponId { get; set; } 
        public Coupon Coupon { get; set; }
    }
}