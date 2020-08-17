using System.Collections.Generic;

namespace HerStory.Core.Entities
{
    public class Basket : BaseEntity
    {
        public string ClientSecret { get; set; }
        public decimal ShippingPrice { get; set; }

        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}