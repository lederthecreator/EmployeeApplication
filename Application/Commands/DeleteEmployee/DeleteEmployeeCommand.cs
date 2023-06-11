using MediatR;

namespace Application.Commands.DeleteEmployee;

/// <summary>
/// Операция удаления сущности.
/// </summary>
public class DeleteEmployeeCommand : IRequest<Unit>
{
    public int Id { get; set; }
}