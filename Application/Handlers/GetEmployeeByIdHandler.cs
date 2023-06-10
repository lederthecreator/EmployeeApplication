using Application.Queries.GetByIdQuery;
using Domain.AggregationModels.EmployeeAggregate;
using MediatR;

namespace Application.Handlers;

public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
{
    private readonly IEmployeeRepository _repository;

    public GetEmployeeByIdHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.FindByIdAsync(request.Id, cancellationToken);
        if (entity == null)
        {
            throw new Exception("Not found");
        }

        return entity;
    }
}