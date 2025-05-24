using AutoMapper;
using VF.Core.InputModels;
using VF.Core.Models;

namespace VF.Application.Mappings;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<CategoryInputModel, CategoryModel>()
            .ForMember(d => d.CreatedAt, o => o.MapFrom(x => DateTime.Now))
            .ForMember(d => d.UpdatedAt, o => o.MapFrom(x => DateTime.Now));

        CreateMap<SubcategoryInputModel, SubcategoryModel>()
            .ForMember(d => d.CreatedAt, o => o.MapFrom(x => DateTime.Now))
            .ForMember(d => d.UpdatedAt, o => o.MapFrom(x => DateTime.Now));
    }
}
