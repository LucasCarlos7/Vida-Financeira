using VF.Core.InputModels;

namespace VF.Core.Interfaces.Services;

public interface IAccountService
{
    Task RegisterAsync(AccountInputModel accountInputModel);
}
