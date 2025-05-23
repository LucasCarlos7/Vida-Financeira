namespace VF.Core.Entities;

public class IncomeTransaction : Transaction
{
    public Account Account { get; set; }
    public bool Received { get; set; }
}
