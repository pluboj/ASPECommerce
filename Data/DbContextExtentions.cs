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
                FirstName = "Stu",
                LastName = "Ratcliffe",
                UserName = "stu@ratcliffe.io",
                Email = "stu@ratcliffe.io",
                EmailConfirmed = true,
                LockoutEnabled = false
            };

             UserManager.CreateAsync(user, "Password1*").GetAwaiter().GetResult();
        }
    }
}