using Microsoft.AspNetCore.Mvc;
using VF.Core.InputModels;
using VF.Core.Interfaces.Services;

namespace VF.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FinancialInstitutionController : ControllerBase
{
    private readonly IFinancialInstitutionService _financialInstitutionService;

    public FinancialInstitutionController(IFinancialInstitutionService financialInstitutionService)
    {
        _financialInstitutionService = financialInstitutionService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync(FinancialInstitutionInputModel inputModel)
    {
        await _financialInstitutionService.RegisterAsync(inputModel);

        return Created();
    }

}
