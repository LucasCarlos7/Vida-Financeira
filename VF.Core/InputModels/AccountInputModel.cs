using VF.Core.Enums;

namespace VF.Core.InputModels;

public class AccountInputModel
{
    public string? AccountDescription { get; set; }
    
#nullable disable
    public string AccountName { get; set; }
    public AccountTypeEnum AccountType { get; set; }
    public Decimal Balance { get; set; } // Saldo atual
    public int FinancialInstitutionId { get; set; }
    public bool IsMainAccount { get; set; } // Conta Principal 0 = Não - 1 = Sim
    public RegistrationTypeEnum RegistrationType { get; set; } // 0 = Manual 1 = Automática
    public bool IsFiled { get; set; } // Conta arquivada - 0 = Não 1 = Sim
    public int UserId { get; set; }
}
