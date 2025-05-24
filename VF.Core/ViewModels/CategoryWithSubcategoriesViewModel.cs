using VF.Core.Enums;

namespace VF.Core.ViewModels;

public class CategoryWithSubcategoriesViewModel
{
    public int IdCategory { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public TransactionTypeEnum TransactionType { get; set; }
    public List<SubcategoryViewModel>? Subcategories { get; set; } = new List<SubcategoryViewModel>();
}
