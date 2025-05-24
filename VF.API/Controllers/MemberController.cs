using Microsoft.AspNetCore.Mvc;
using VF.Core.InputModels;
using VF.Core.Interfaces.Services;

namespace VF.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MemberController : ControllerBase
{
    private readonly IMemberService _memberService;

    public MemberController(IMemberService memberService)
    {
        _memberService = memberService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync(MemberInputModel inputModel)
    {
        await _memberService.RegisterAsync(inputModel);

        return Created();
    }


    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync()
    {
        var members = await _memberService.GetAllAsync();

        return Ok(members);
    }

}
