using VF.Core.Enums;

namespace VF.Core.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public string? AccountDescription { get; set; }    
        public string AccountName { get; set; }
        public AccountTypeEnum AccountType { get; set; }
        public Decimal Balance { get; set; } // Saldo atual
        public bool IsMainAccount { get; set; } // Conta Principal 0 = Não - 1 = Sim
        public RegistrationTypeEnum RegistrationType { get; set; } // 0 = Manual 1 = Automática
        public bool IsFiled { get; set; } // Conta arquivada - 0 = Não 1 = Sim
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid FinancialInstitutionId { get; set; }
        public FinancialInstitution FinancialInstitution { get; set; }

        public ICollection<CreditCard> CreditCards { get; set; } = new List<CreditCard>();
    }
}