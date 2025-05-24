using AutoMapper;
using VF.Core.InputModels;
using VF.Core.Interfaces.Repositories;
using VF.Core.Interfaces.Services;
using VF.Core.Models;
using VF.Core.ViewModels;

namespace VF.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService
    (
        ICategoryRepository categoryRepository,
        IMapper mapper
    )
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task RegisterCategoryAsync(CategoryInputModel inputModel)
    {
        if (inputModel is null)
            throw new InvalidOperationException("Categoria não pode ser vazio");

        var newCategory = _mapper.Map<CategoryModel>(inputModel);

        await _categoryRepository.RegisterCategoryAsync(newCategory);
    }

    public async Task RegisterSubcategoryAsync(SubcategoryInputModel inputModel)
    {
        if (inputModel is null)
            throw new InvalidOperationException("Subcategoria não pode ser vazio");

        var newSubcategory = _mapper.Map<SubcategoryModel>(inputModel);

        await _categoryRepository.RegisterSubcategoryAsync(newSubcategory);
    }

    public async Task<List<CategoryWithSubcategoriesViewModel>> GetCategoriesWithSubcategoriesAsync
    (
        int transactionType
    )
    {
        var categories = await _categoryRepository.GetCategoriesAsync(transactionType);

        if (categories is null || !categories.Any())
            throw new InvalidOperationException("Nenhuma categoria encontrada.");

        var categoryIds = categories.Select(c => c.IdCategory).ToList();

        var subcategories = await _categoryRepository.GetSubcategoriesAsync(categoryIds);

        // vinculando subcategorias nas categorias
        foreach (var category in categories)
        {
            category.Subcategories = subcategories
                .Where(s => s.CategoryId == category.IdCategory)
                .ToList();
        }

        return categories;
    }

}
