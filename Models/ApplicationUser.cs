using Microsoft.AspNetCore.Identity;

namespace GF_TodoApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
