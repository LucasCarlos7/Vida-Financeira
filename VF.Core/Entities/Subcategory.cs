namespace VF.Core.Entities;

public class Subcategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
