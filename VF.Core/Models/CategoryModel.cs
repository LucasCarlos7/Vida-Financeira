using VF.Core.Enums;

namespace VF.Core.Models;

public class CategoryModel
{
    public string Name { get; set; }
    public string Color { get; set; }
    public TransactionTypeEnum TransactionType { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
