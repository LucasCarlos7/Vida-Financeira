using VF.Core.InputModels;
using VF.Core.Models;

namespace VF.Core.Interfaces.Repositories;

public interface IUserRepository
{
    Task RegisterAsync(UserModel userModel);
}
