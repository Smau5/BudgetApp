using AutoMapper;
using BudgetApp.API.Dto;
using BudgetApp.Core.BudgetAggregate;

namespace BudgetApp.API.MapperProfiles;

public class BudgetProfile : Profile
{
    public BudgetProfile()
    {
        CreateMap<Budget, BudgetDto>();
    }
}