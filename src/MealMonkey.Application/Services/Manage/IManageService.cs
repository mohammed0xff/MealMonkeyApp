using MealMonkey.Application.Common;

namespace MealMonkey.Application.Services.ManageService
{
    public interface IManageService
    {
        Task<string> AddToRoleAsync(RoleDto model);

        Task<string> RemoveFromRoleAsync(RoleDto model);
    }
}
