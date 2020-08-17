using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HerStory.Core.Entities
{
    public class Coupon : BaseEntity
    {
        [Required]
        [Description("User friendly token create by admin")]
        public string Token { get; set; }

        [Required] public string Title { get; set; }

        [Description("Set true if you want to Give a flat discount of a fixed amount")]
        [Required]
        public bool IsFlat { get; set; } = true;

        [Required]
        [Range(typeof(decimal), "0", "10000")]
        public decimal MaxDiscountAmount { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "100")]
        public decimal DiscountPercentage { get; set; }

        [Description("Make it false if you want to give a percentage discount with no max value")]
        [Required]
        public bool IsCapApplicable { get; set; } = true;
    }
}