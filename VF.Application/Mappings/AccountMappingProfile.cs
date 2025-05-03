using AutoMapper;
using VF.Core.InputModels;
using VF.Core.Models;

namespace VF.Application.Mappings;

public class AccountMappingProfile : Profile
{
    public AccountMappingProfile()
    {
        CreateMap<AccountInputModel, AccountModel>()
            .ForMember(d => d.CreatedAt, o => o.MapFrom(x => DateTime.UtcNow))
            .ForMember(d => d.UpdatedAt, o => o.MapFrom(x => DateTime.UtcNow));
    }
}
