using VF.Core.Entities;
using VF.Core.InputModels;

namespace VF.Core.Interfaces.Services;

public interface IUserService
{
    Task RegisterAsync(UserInputModel inputModel);
}
