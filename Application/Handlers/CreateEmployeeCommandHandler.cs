using Application.Commands.CreateEmployee;
using Domain.AggregationModels.EmployeeAggregate;
using MediatR;
using Persistence.UnitOfWork;

namespace Application.Handlers;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
{
    private readonly IEmployeeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeCommandHandler(IEmployeeRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var fullName = new FullName(request.Surname, request.FirstName);
        if (!string.IsNullOrEmpty(request.PatronymicName))
        {
            fullName.SetPatronymicName(request.PatronymicName);
        }

        var newEmployee = new Employee(
            new Department(request.DepartmentCode, request.DepartmentFullName),
            fullName,
            new BirthDate(request.BirthDate),
            new DateOfEmployment(request.DateOfEmployment),
            new Salary(request.Salary)
        );

        var createResult = await _repository.CreateAsync(newEmployee, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return createResult.Id;
    }
}