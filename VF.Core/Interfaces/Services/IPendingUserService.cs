using VF.Core.Entities;
using VF.Core.InputModels;
using VF.Core.Models;

namespace VF.Core.Interfaces.Services;

public interface IPendingUserService
{
    Task AddPendingUserAsync(UserInputModel user);
    Task<UserInputModel?> GetPendingUserAsync(string email);
    Task RemovePendingUserAsync(string email);
}
