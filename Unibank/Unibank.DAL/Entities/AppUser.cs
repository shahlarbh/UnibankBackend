using Microsoft.AspNetCore.Identity;

namespace Unibank.DAL.Entities
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; }
    }
}
