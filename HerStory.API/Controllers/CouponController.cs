using HerStory.Core.Entities;
using HerStory.Infra.Services;

namespace HerStory.API.Controllers
{
    public class CouponController : BaseController<Coupon>
    {
        public CouponController(CouponService service) : base(service)
        {
        }
    }
}