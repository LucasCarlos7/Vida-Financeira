using AutoMapper;
using VF.Core.InputModels;
using VF.Core.Models;

namespace VF.Application.Mappings;

public class FinancialInstitutionMappingProfile : Profile
{
    public FinancialInstitutionMappingProfile()
    {
        CreateMap<FinancialInstitutionInputModel, FinancialInstitutionModel>()
            .ForMember(d => d.CreatedAt, o => o.MapFrom(x => DateTime.Now))
            .ForMember(d => d.UpdatedAt, o => o.MapFrom(x => DateTime.Now));
    }
}
