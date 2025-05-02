using Microsoft.AspNetCore.Mvc;
using VF.Core.InputModels;
using VF.Core.Interfaces.Services;

namespace VF.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> registerAsync(UserInputModel user)
    {
        await _userService.RegisterAsync(user);

        return Created();
    }

}
