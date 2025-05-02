namespace VF.Core.Interfaces.Services;

public interface IEmailService
{
    Task SendVerificationCodeAsync(string toEmail);

    Task<bool> ValidateVerificatonCodeAsync(string toEmail, string code);
}
