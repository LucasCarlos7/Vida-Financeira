using VF.Core.Entities;
using VF.Core.Enums;

namespace VF.Core.InputModels;

public class CreditCardInputModel
{
    public string CardName { get; set; }
    public CardFlag CardFlag { get; set; } // Enum Bandeira Cartão
    public int DueDay { get; set; } // Dia de vencimento
    public decimal MothlyLimit { get; set; } // Limite Mensal
    public int AccountId { get; set; }
}
