namespace VF.Core.Entities;

public class IncomeTransaction : Transaction
{
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
    
    public bool Received { get; set; }
}
