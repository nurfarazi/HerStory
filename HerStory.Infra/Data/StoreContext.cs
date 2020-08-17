using HerStory.Core.Entities;
using HerStory.Core.Entities.OrderAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HerStory.Infra.Data
{
    public class StoreContext : IdentityDbContext<AppUser>
    {
        public StoreContext()
        {
        }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BasketItem>()
                .HasKey(u => new {u.Id, u.ProductId});

            builder.Ignore<Address>();
            builder.Ignore<ProductItemOrdered>();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CouponedOrder> CouponedOrders { get; set; }
    }
}