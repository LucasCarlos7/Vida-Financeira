using AutoMapper;
using VF.Core.InputModels;
using VF.Core.Models;

namespace VF.Application.Mappings;

public class CreditCardMappingProfile : Profile
{
    public CreditCardMappingProfile()
    {
        CreateMap<CreditCardInputModel, CreditCardModel>()
            .ForMember(x => x.CreatedAt, o => o.MapFrom(d => DateTime.Now))
            .ForMember(x => x.UpdatedAt, o => o.MapFrom(d => DateTime.Now));
    }
}
