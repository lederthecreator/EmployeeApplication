using System.Globalization;
using Application.Commands.UpdateEmployee;
using Domain.AggregationModels.EmployeeAggregate;
using MediatR;
using Persistence.UnitOfWork;

namespace Application.Handlers;

/// <summary>
/// Обработчик операции редактирования записи.
/// </summary>
public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
{
    private readonly IEmployeeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEmployeeCommandHandler(IEmployeeRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.FindByIdAsync(request.Id, cancellationToken);
        if (entity == null)
        {
            throw new ArgumentException("Not found");
        }

        if (entity.Department.Code != request.DepartmentCode)
        {
            entity.Department.SetCode(request.DepartmentCode);
        }

        if (entity.Department.FullName != request.DepartmentFullName)
        {
            entity.Department.SetFullName(request.DepartmentFullName);
        }

        if (entity.FullName.Surname != request.Surname)
        {
            entity.FullName.SetSurname(request.Surname);
        }
        
        if (entity.FullName.FirstName != request.FirstName)
        {
            entity.FullName.SetFirstName(request.FirstName);
        }
        
        if (request.PatronymicName is not null && entity.FullName.PatronymicName != request.PatronymicName)
        {
            entity.FullName.SetPatronymicName(request.PatronymicName);
        }

        var cultureInfo = new CultureInfo("ru-RU");
        if (DateOnly.TryParse(request.BirthDate, cultureInfo, out var requestBirthDate) 
            && entity.BirthDate.Value != requestBirthDate)
        {
            entity.BirthDate.SetBirthDate(requestBirthDate);
        }

        if (DateOnly.TryParse(request.DateOfEmployment, cultureInfo, out var requestDateOfEmployment)
            && entity.DateOfEmployment.Value != requestDateOfEmployment)
        {
            entity.DateOfEmployment.SetDateOfEmployment(requestDateOfEmployment);
        }

        if (decimal.TryParse(request.Salary, out var parsedSalary))
        {
            if (entity.Salary.Value != parsedSalary)
            {
                entity.Salary.SetSalary(parsedSalary);
            }
        }

        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}