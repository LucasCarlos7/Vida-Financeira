using VF.Core.Enums;

namespace VF.Core.Entities;

public class CreditCard
{
    public int Id { get; set; }
    public string CardName { get; set; }
    public CardFlag CardFlag { get; set; } // Enum Bandeira Cartão
    public DateTime DueDate { get; set; } // Data de vencimento
    public decimal MothlyLimit { get; set; } // Limite Mensal
    
    public int AccountId { get; set; }
    public Account Account { get; set; }
}
