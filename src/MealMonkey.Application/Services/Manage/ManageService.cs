using MealMonkey.Application.Common;
using MealMonkey.Domain.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;

namespace MealMonkey.Application.Services.ManageService
{
    public class ManageService : IManageService
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
            public async Task<ServiceResult> AddToRoleAsync(RoleDto model)
            {
                ServiceResult serviceResult = new();

                var user = await _userManager.FindByIdAsync(model.UserId);

                if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
                {
                    serviceResult.Msg = "Invalid user ID or Role";
                    return serviceResult;
                }

                if (await _userManager.IsInRoleAsync(user, model.Role))
                {
                    serviceResult.Msg = "User Is already assigned to this role";
                    return serviceResult;
                }

                var result = await _userManager.AddToRoleAsync(user, model.Role);
                if (!result.Succeeded)
                    serviceResult.Msg = "Something went wrong, Please Try Again";
                else
                    serviceResult.Msg = $"{user.UserName} Is Added Successfully to {model.Role}.";

                return serviceResult;
            }

            public async Task<ServiceResult> RemoveFromRoleAsync(RoleDto model)
            {
                ServiceResult serviceResult = new();

                var user = await _userManager.FindByIdAsync(model.UserId);

                if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
                {
                    serviceResult.Msg = "Invalid user ID or Role";
                    return serviceResult;
                }

                var result = await _userManager.RemoveFromRoleAsync(user, model.Role);
                if (!result.Succeeded)
                    serviceResult.Msg = "Something went wrong, Please Try Again";
                else
                    serviceResult.Msg = $"{user.UserName} Is Removed Successfully From {model.Role}.";

                return serviceResult;
            }
        }
    }
}
