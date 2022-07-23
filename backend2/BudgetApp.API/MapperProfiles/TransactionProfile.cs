using AutoMapper;
using BudgetApp.API.Dto;
using BudgetApp.Core.TransactionAggregate;

namespace BudgetApp.API.MapperProfiles;

public class TransactionProfile : Profile
{
    public TransactionProfile()
    {
        CreateMap<Transaction, TransactionDto>();
    }
}