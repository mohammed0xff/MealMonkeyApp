using MealMonkey.Application.Common;

namespace MealMonkey.Application.Services.ManageService
{
    public interface IManageService
    {
        Task<ServiceResult> AddToRoleAsync(RoleDto model);
        Task<ServiceResult> RemoveFromRoleAsync(RoleDto model);
    }
}