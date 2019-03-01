using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Forum.Models.Account
{
    public class AppUser : IdentityUser
    {
        public IList<Update> Updates { get; set; }
    }
}
