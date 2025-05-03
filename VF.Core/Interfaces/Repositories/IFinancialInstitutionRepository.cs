using VF.Core.Models;

namespace VF.Core.Interfaces.Repositories;

public interface IFinancialInstitutionRepository
{
    Task RegisterAsync(FinancialInstitutionModel financialInstitutionModel);
}
