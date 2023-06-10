using MediatR;

namespace Application.Commands.DeleteEmployee;

public class DeleteEmployeeCommand : IRequest<Unit>
{
    public int Id { get; set; }
}