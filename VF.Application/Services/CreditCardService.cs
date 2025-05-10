using AutoMapper;
using VF.Core.InputModels;
using VF.Core.Interfaces.Repositories;
using VF.Core.Interfaces.Services;
using VF.Core.Models;

namespace VF.Application.Services;

public class CreditCardService : ICreditCardSevice
{
    private readonly ICreditCardRepository _creditCardRepository;
    private readonly IMapper _mapper;

    public CreditCardService
    (
        ICreditCardRepository creditCardRepository, 
        IMapper mapper
    )
    {
        _creditCardRepository = creditCardRepository;
        _mapper = mapper;
    }


    public async Task RegisterAsync(CreditCardInputModel inputModel)
    {
        if (inputModel is null)
            throw new InvalidOperationException("Cartão não pode ser vazio.");

        var newCreditCard = _mapper.Map<CreditCardModel>(inputModel);

        await _creditCardRepository.RegisterAsync(newCreditCard);
    }

}
