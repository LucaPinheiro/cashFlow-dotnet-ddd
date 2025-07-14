using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;

namespace CashFlow.Application.UseCases.Expenses.GetById;

public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
{
    private readonly IExpensesRepository _repository;
    private readonly IMapper _mapper;

    public GetExpenseByIdUseCase(IExpensesRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResponseExpenseJson> Execute(long id)
    {
        var result = await _repository.GetById(id);
        return _mapper.Map<ResponseExpenseJson>(result);
    }
}