using Microsoft.AspNetCore.Identity;

namespace Eventures.Data.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UCN { get; set; }
    }
}
