using Azure;
using VF.Core.Entities;
using VF.Core.InputModels;
using VF.Core.Interfaces.Repositories;
using VF.Core.Interfaces.Services;
using VF.Core.Models;

namespace VF.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task RegisterAsync(UserInputModel inputModel)
    {
        if (inputModel is null)
            throw new Exception("Usuário não pode ser vazio!");

        var newUser = new UserModel
        {
            Name = inputModel.Name,
            Email = inputModel.Email,
            Cpf = inputModel.Cpf,
            PasswordHash = inputModel.PasswordHash,
            Phone = inputModel.Phone,
        };

        newUser.CreatedAt = DateTime.UtcNow;
        newUser.UpdatedAt = DateTime.UtcNow;

        await _userRepository.RegisterAsync(newUser);
    }

}
