using HerStory.Core.Entities.OrderAggregate;

namespace HerStory.API.Models
{
    public class OrderDto
    {
        public int BasketId { get; set; }
        public string Email { get; set; }
        public int DeliveryMethodId { get; set; }
        public Address ShipToAddress { get; set; }
    }
}