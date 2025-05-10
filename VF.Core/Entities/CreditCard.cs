using VF.Core.Enums;

namespace VF.Core.Entities;

public class CreditCard
{
    public int Id { get; set; }
    public string CardName { get; set; }
    public CardFlag CardFlag { get; set; } // Enum Bandeira Cartão
    public int DueDay { get; set; } // Dia de vencimento
    public decimal MothlyLimit { get; set; } // Limite Mensal
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public int AccountId { get; set; }
    public Account Account { get; set; }
}
