using Domain.AggregationModels.EmployeeAggregate;
using MediatR;

namespace Application.Queries.GetByIdQuery;

public class GetEmployeeByIdQuery : IRequest<Employee>
{
    public int Id { get; set; }
}