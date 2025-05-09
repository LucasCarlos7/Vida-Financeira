using VF.Core.Models;

namespace VF.Core.Interfaces.Repositories;

public interface ICreditCardRepository
{
    Task RegisterAsync(CreditCardModel creditCard);
}
