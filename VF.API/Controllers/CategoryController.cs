using Microsoft.AspNetCore.Mvc;
using VF.Core.InputModels;
using VF.Core.Interfaces.Services;

namespace VF.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("RegisterCategory")]
    public async Task<IActionResult> RegisterCategoryAsync(CategoryInputModel inputModel)
    {
        await _categoryService.RegisterCategoryAsync(inputModel);

        return Created();
    }

    [HttpPost("RegisterSubcategory")]
    public async Task<IActionResult> RegisterSubategoryAsync(SubcategoryInputModel inputModel)
    {
        await _categoryService.RegisterSubcategoryAsync(inputModel);

        return Created();
    }

    [HttpGet("Categories")]
    public async Task<IActionResult> GetAllCategoriesAsync(int transactionType)
    {
        var categories = await _categoryService.GetCategoriesWithSubcategoriesAsync(transactionType);

        return Ok(categories);
    }

}
