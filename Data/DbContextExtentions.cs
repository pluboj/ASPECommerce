using ASP.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace ASP.Data
{
    public static class DbContextExtentions
    {
        public static UserManager<AppUser> UserManager
        { get; set; }

        public static void EnsureSeeded(this Context  
        context) 
        {
            var user = new AppUser
            {
                FirstName = "James",
                LastName = "Smith",
                UserName = "jsmith@jamesemail.com",
                Email = "jsmith@jamesemail.com",
                EmailConfirmed = true,
                LockoutEnabled = false
            };

             UserManager.CreateAsync(user, "Password1*").GetAwaiter().GetResult();
        }
    }
}