using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;
using Unibank.DAL.Entities;

namespace Unibank.MVC.Data
{
    public class DataInitializer
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _dbContext;

        public DataInitializer(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        public async Task SeedData()
        {
            await _dbContext.Database.MigrateAsync();

            var roles = new List<string> { RoleConstants.AdminRole, RoleConstants.UserRole };

            foreach (var role in roles)
            {
                var existRole = await _roleManager.FindByNameAsync(role);

                if (existRole != null)
                    continue;

                var roleResult = await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = role
                });
            }

            var existUser = await _userManager.FindByNameAsync("Admin");

            if (existUser != null)
            {
                return;
            }

            var user = new AppUser
            {
                UserName = "Admin",
                Fullname = "Admin",
                Email = "shahlarbh@code.edu.az",
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, "21041998");

            result = await _userManager.AddToRoleAsync(user, RoleConstants.AdminRole);
        }
    }
}
