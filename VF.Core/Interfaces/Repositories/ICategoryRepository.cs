using VF.Core.Models;
using VF.Core.ViewModels;

namespace VF.Core.Interfaces.Repositories;

public interface ICategoryRepository
{
    Task RegisterCategoryAsync(CategoryModel category);

    Task RegisterSubcategoryAsync(SubcategoryModel subcategory);

    Task<List<CategoryWithSubcategoriesViewModel>> GetCategoriesAsync(int transactionType);

    Task<List<SubcategoryViewModel>> GetSubcategoriesAsync(List<int> categoryIds);

    Task RemoveAsync(int id);
}
