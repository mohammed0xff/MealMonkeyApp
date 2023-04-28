using MealMonkey.Application.Common;
using MealMonkey.Domain.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;

namespace MealMonkey.Application.Services.ManageService
{
    public class ManageService : IManageService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ManageService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Manage User Roles
        public async Task<string> AddToRoleAsync(RoleDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
                return "Invalid user ID or Role";

            if (await _userManager.IsInRoleAsync(user, model.Role))
                return "User Is already assigned to this role";

            var result = await _userManager.AddToRoleAsync(user, model.Role);

            return result.Succeeded ? $"{user.UserName} Is Added Successfully to {model.Role}." : "Something went wrong, Please Try Again";
        }

        public async Task<string> RemoveFromRoleAsync(RoleDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
                return "Invalid user ID or Role";

            var result = await _userManager.RemoveFromRoleAsync(user, model.Role);

            return result.Succeeded ? $"{user.UserName} Is Added Successfully to {model.Role}." : "Something went wrong, Please Try Again";
        }
    }
}
