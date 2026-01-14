using Microsoft.AspNetCore.Identity;

namespace Demo.Identity.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string EyeColor { get; set; } = default!;
    }
}
