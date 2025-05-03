using VF.Core.InputModels;

namespace VF.Core.Interfaces.Services;

public interface IFinancialInstitutionService
{
    Task RegisterAsync(FinancialInstitutionInputModel inputModel);
}
