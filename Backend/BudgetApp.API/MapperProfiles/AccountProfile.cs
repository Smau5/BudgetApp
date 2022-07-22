using AutoMapper;
using BudgetApp.API.Dto;
using BudgetApp.Core.BudgetAggregate;
using BudgetApp.Core.TransactionAggregate;

namespace BudgetApp.API.MapperProfiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<Account, AccountDto>();
    }
}