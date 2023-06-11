using System.Linq.Expressions;
using Domain.AggregationModels.EmployeeAggregate;
using MediatR;

namespace Application.Queries.ListQuery;

/// <summary>
/// Запрос получения всех записей.
/// TODO: Сделать парсинг Expression в контроллере.
/// </summary>
public class GetAllQuery : IRequest<IEnumerable<Employee>>
{
    public Expression<Func<Employee, bool>>? Filter { get; set; }
    
    public Func<IQueryable<Employee>, IOrderedQueryable<Employee>>? OrderBy { get; set; }
}