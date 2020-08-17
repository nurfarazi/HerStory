using System.ComponentModel.DataAnnotations;

namespace HerStory.Core.Entities
{
  public class Product : BaseEntity
  {
    [Required] public string Title { get; set; }
    [Required] public string Description { get; set; }
    [Required] public string Image { get; set; }
    [Required] public decimal Price { get; set; }

    public ProductType ProductType { get; set; }
    [Required] public int ProductTypeId { get; set; }
  }
}