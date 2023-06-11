using MediatR;

namespace Application.Commands.CreateEmployee;

/// <summary>
/// Команда создания сотрудника. Возвращает идентификатор созданной сущности.
/// </summary>
public class CreateEmployeeCommand : IRequest<int> 
{
    public string DepartmentCode { get; set; }
    
    public string DepartmentFullName { get; set; }
    
    public string Surname { get; set; }
    
    public string FirstName { get; set; }
    
    public string? PatronymicName { get; set; }
    
    public string BirthDate { get; set; }
    
    public string DateOfEmployment { get; set; }
    
    public string Salary { get; set; }
}