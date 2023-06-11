using Domain.AggregationModels.EmployeeAggregate;
using MediatR;

namespace Application.Queries.GetByIdQuery;

/// <summary>
/// Запрос получения записи по идентификатору. Возвращает полученную запись.
/// </summary>
public class GetEmployeeByIdQuery : IRequest<Employee>
{
    public int Id { get; set; }
}