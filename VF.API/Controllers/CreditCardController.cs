using Microsoft.AspNetCore.Mvc;
using VF.Core.InputModels;
using VF.Core.Interfaces.Services;

namespace VF.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CreditCardController : ControllerBase
{
    private readonly ICreditCardSevice _creditCardSevice;

    public CreditCardController(ICreditCardSevice creditCardSevice)
    {
        _creditCardSevice = creditCardSevice;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterAsync(CreditCardInputModel inputModel)
    {
        await _creditCardSevice.RegisterAsync(inputModel);

        return Created();
    }

}
