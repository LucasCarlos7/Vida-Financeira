using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using VF.Application.Utilities;
using VF.Core.Interfaces.Services;
using VF.Infrastructure.Configurations;

namespace VF.Application.Services;

public class EmailService : IEmailService
{
    private readonly CredentialsEmailConfiguration _credentialsEmail;
    //private readonly IPendingUserService _pendingUserService;
    private readonly IUserService _userService;

    public EmailService
    (
        IOptions<CredentialsEmailConfiguration> credentialsEmail,
        //IPendingUserService pendingUserService,
        IUserService userService
    )
    {
        _credentialsEmail = credentialsEmail.Value;
        //_pendingUserService = pendingUserService;
        _userService = userService;
    }


    public async Task SendVerificationCodeAsync(string toEmail)
    {
        //var pendingUser = await _pendingUserService.GetPendingUserAsync(toEmail);

       // if (pendingUser is not null)
        //    throw new InvalidOperationException("Já existe um processo de verificação pendente.");

        var code = CodeGeneratorUtility.GenerateCode();
        VerificationCodeStoreUtility.StoreCode(toEmail, code);

        string subject = "Código de verificação <strong>Vida Finaceira<strong>";
        string body = $"Seu código de verificação é: <b>{code}<b>";

        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = _credentialsEmail.Port,
            Credentials = new NetworkCredential(_credentialsEmail.FromEmail, _credentialsEmail.AppPassword),
            EnableSsl = _credentialsEmail.EnableSsl
        };

        var mailMessage = new MailMessage(_credentialsEmail.FromEmail, toEmail, subject, body)
        {
            IsBodyHtml = true
        };

        await smtpClient.SendMailAsync(mailMessage);
    }

    public async Task<bool> ValidateVerificatonCodeAsync(string toEmail, string code)
    {
        //var pendingUser = await _pendingUserService.GetPendingUserAsync(toEmail);

        //if (pendingUser is not null)
            //throw new InvalidOperationException("Nenhum cadastro pendente para esse e-mail.");

        var isValid = VerificationCodeStoreUtility.ValidateCode(toEmail, code);

        if (!isValid)
            throw new InvalidOperationException("Código inválido ou expirado.");

        // var user = pendingUser;
        // user.CreatedAt = DateTime.Now;
        // user.UpdatedAt = DateTime.Now;

        // await _userService.RegisterAsync(user);
        // await _pendingUserService.RemovePendingUserAsync(user.Email);
        return true;
    }
}
