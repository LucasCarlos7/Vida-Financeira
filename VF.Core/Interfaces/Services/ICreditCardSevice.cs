using VF.Core.InputModels;

namespace VF.Core.Interfaces.Services;

public interface ICreditCardSevice
{
    Task RegisterAsync(CreditCardInputModel inputModel);
}
