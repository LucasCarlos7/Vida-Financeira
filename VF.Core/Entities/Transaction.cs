namespace VF.Core.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public decimal TransactionValue { get; set; }
    public string Description { get; set; }
    public Category? Category { get; set; }
    public DateTime Date { get; set; }
    public Member? Member { get; set; }
    public List<Tag>? Tags { get; set; }
}
