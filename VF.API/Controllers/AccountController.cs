using Microsoft.AspNetCore.Mvc;
using VF.Core.InputModels;
using VF.Core.Interfaces.Services;

namespace VF.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync(AccountInputModel inputModel)
    {
        await _accountService.RegisterAsync(inputModel);

        return Created();
    }

}
