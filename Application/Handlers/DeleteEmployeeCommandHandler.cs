using Application.Commands.DeleteEmployee;
using Domain.AggregationModels.EmployeeAggregate;
using MediatR;
using Persistence.UnitOfWork;

namespace Application.Handlers;

/// <summary>
/// Обработчик операции удаления.
/// </summary>
public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
{
    private readonly IEmployeeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmployeeCommandHandler(IEmployeeRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.FindByIdAsync(request.Id, cancellationToken);
        if (entity == null)
        {
            throw new Exception("Not found");
        }

        _repository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}