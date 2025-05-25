using VF.Core.Entities;
using VF.Core.Enums;

namespace VF.Core.Models;

public class CreditCardModel
{
    public Guid Id { get; set; }
    public string CardName { get; set; }
    public CardFlagEnum CardFlag { get; set; } // Enum Bandeira Cartão
    public int DueDay { get; set; } // Dia de vencimento
    public decimal MothlyLimit { get; set; } // Limite Mensal
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid AccountId { get; set; }
}
