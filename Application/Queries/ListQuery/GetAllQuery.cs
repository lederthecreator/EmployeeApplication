using System.Linq.Expressions;
using Domain.AggregationModels.EmployeeAggregate;
using MediatR;

namespace Application.Queries.ListQuery;

public class GetAllQuery : IRequest<IEnumerable<Employee>>
{
    public Expression<Func<Employee, bool>>? Filter { get; set; }

    public Func<IQueryable<Employee>, IOrderedQueryable<Employee>>? OrderBy { get; set; }
}