using AutoMapper;
using VF.Core.InputModels;
using VF.Core.Interfaces.Repositories;
using VF.Core.Interfaces.Services;
using VF.Core.Models;

namespace VF.Application.Services;

public class FinancialInstitutionService : IFinancialInstitutionService
{
    private readonly IFinancialInstitutionRepository _financialInstitutionRepository;
    private readonly IMapper _mapper;

    public FinancialInstitutionService
    (
        IFinancialInstitutionRepository financialInstitutionRepository, 
        IMapper mapper
    )
    {
        _financialInstitutionRepository = financialInstitutionRepository;
        _mapper = mapper;
    }

    public async Task RegisterAsync(FinancialInstitutionInputModel inputModel)
    {
        if (inputModel == null)
            throw new InvalidOperationException("Não pode ser vazio!");

        var newInstitution = _mapper.Map<FinancialInstitutionModel>(inputModel);

        await _financialInstitutionRepository.RegisterAsync(newInstitution);
    }
}
