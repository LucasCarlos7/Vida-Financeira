using VF.Core.Enums;

namespace VF.Core.Entities;

public class Category
{
#nullable disable
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public TransactionTypeEnum TransactionType { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<Subcategory> Subcategories { get; set; } = new List<Subcategory>();
}
