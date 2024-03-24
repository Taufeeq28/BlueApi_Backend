using Microsoft.AspNetCore.Identity;

namespace BlueApi_Backend.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
    }
}
