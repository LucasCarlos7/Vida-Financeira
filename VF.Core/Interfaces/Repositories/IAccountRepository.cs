using VF.Core.Models;

namespace VF.Core.Interfaces.Repositories;

public interface IAccountRepository
{
    Task RegisterAsync(AccountModel accountModel);
}
