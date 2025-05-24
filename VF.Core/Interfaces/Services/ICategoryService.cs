using VF.Core.InputModels;
using VF.Core.ViewModels;

namespace VF.Core.Interfaces.Services;

public interface ICategoryService
{
    Task RegisterCategoryAsync(CategoryInputModel inputModel);

    Task RegisterSubcategoryAsync(SubcategoryInputModel inputModel);

    Task<List<CategoryWithSubcategoriesViewModel>> GetCategoriesWithSubcategoriesAsync
    (
        int transactionType
    );
}
