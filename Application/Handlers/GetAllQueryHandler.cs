using Application.Queries.ListQuery;
using Domain.AggregationModels.EmployeeAggregate;
using MediatR;

namespace Application.Handlers;

/// <summary>
/// Обработчик запроса получения всех записей.
/// </summary>
public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<Employee>>
{
    private readonly IEmployeeRepository _repository;

    public GetAllQueryHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Employee>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var baseQuery = _repository.GetAll().AsQueryable();

        if (request.Filter is not null)
        {
            baseQuery = baseQuery.Where(request.Filter);
        }

        if (request.OrderBy is not null)
        {
            baseQuery = request.OrderBy(baseQuery);
        }

        var query = baseQuery.ToList();

        return query;
    }
}