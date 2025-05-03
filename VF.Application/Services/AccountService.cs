using AutoMapper;
using VF.Core.InputModels;
using VF.Core.Interfaces.Repositories;
using VF.Core.Interfaces.Services;
using VF.Core.Models;

namespace VF.Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public AccountService
    (
        IAccountRepository accountRepository, 
        IMapper mapper
    )
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }


    public async Task RegisterAsync(AccountInputModel accountInputModel)
    {
        if (accountInputModel is null)
            throw new InvalidOperationException("Conta não pode ser vazio!");

        var newAccount = _mapper.Map<AccountModel>(accountInputModel);

        await  _accountRepository.RegisterAsync(newAccount);
    }

}
