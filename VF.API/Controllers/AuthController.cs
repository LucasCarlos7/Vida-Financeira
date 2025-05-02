using Microsoft.AspNetCore.Mvc;
using VF.Core.Entities;
using VF.Core.InputModels;
using VF.Core.Interfaces.Services;

namespace VF.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IEmailService _emailService;
    private readonly IPendingUserService _pendingUserService;

    public AuthController
    (
        IEmailService emailService,
        IPendingUserService pendingUserService
    )
    {
        _emailService = emailService;
        _pendingUserService = pendingUserService;
    }

    [HttpPost("AddPending")]
    public async Task<IActionResult> AddPendingUserAsync(UserInputModel user)
    {
        await _pendingUserService.AddPendingUserAsync(user);

        return Ok();
    }

    [HttpPost("ValidateCode")]
    public async Task<IActionResult> ValidateCodeAsync([FromQuery] string email, [FromQuery] string code)
    {
        await _emailService.ValidateVerificatonCodeAsync(email, code);

        return Ok("Cadastro concluído com sucesso.");
    }
}
