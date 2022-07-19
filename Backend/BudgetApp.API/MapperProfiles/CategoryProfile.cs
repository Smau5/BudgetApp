using AutoMapper;
using BudgetApp.API.Dto;
using BudgetApp.Core.BudgetAggregate;

namespace BudgetApp.API.MapperProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>();
    }
}