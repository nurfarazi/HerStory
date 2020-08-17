using Microsoft.AspNetCore.Identity;

namespace HerStory.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }   
    }
}