using VF.Core.Enums;

namespace VF.Core.InputModels;

public class CategoryInputModel
{
    public string Name { get; set; }
    public string Color { get; set; }
    public TransactionTypeEnum TransactionType { get; set; }
}
