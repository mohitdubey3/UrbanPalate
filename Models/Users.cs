using Microsoft.AspNetCore.Identity;
using UrbanPalate.Models;

namespace UrbanPalate.Models
{
    public class Users:IdentityUser
    {
        public string Name { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
