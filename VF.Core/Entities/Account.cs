using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using VF.Core.Enums;

namespace VF.Core.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string? AccountDescription { get; set; }

 #nullable disable       
        public string AccountName { get; set; }
        public AccountType AccountType { get; set; }
        public Decimal Balance { get; set; } // Saldo atual

        // Referencia a classe base
        public int FinancialInstitutionId { get; set; }
        public FinancialInstitution FinancialInstitution { get; set; } = null!;

        public bool IsMainAccount { get; set; } // Conta Principal 0 = Não - 1 = Sim
        public RegistrationType RegistrationType { get; set; } // 0 = Manual 1 = Automática
        public bool IsFiled { get; set; } // Conta arquivada - 0 = Não 1 = Sim
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Referência à classe base
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}