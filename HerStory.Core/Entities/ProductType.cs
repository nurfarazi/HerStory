using System.ComponentModel.DataAnnotations;

namespace HerStory.Core.Entities
{
    public class ProductType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}