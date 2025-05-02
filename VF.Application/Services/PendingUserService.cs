using VF.Core.InputModels;
using VF.Core.Interfaces.Services;

namespace VF.Application.Services;

public class PendingUserService : IPendingUserService
{
    private static readonly Dictionary<string, UserInputModel> _pendingUsers = new();
    private readonly IEmailService _emailService;

    public PendingUserService(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public async Task AddPendingUserAsync(UserInputModel user)
    {
        if (user is null)
            throw new InvalidOperationException("Usuário informado não pode ser vazio.");

        else if (_pendingUsers.ContainsKey(user.Email))
            throw new InvalidOperationException("Já existe um processo de verificação pendente.");

        // adicionando o usuário no dictionary
        _pendingUsers[user.Email] = user;

        await _emailService.SendVerificationCodeAsync(user.Email);
    }

    public Task<UserInputModel?> GetPendingUserAsync(string email)
    {
        _pendingUsers.TryGetValue(email, out var user);
        return Task.FromResult(user);
    }

    public Task RemovePendingUserAsync(string email)
    {
        _pendingUsers.Remove(email);
        return Task.CompletedTask;
    }

}
