using MediatR;

namespace Application.Commands.UpdateEmployee;

/// <summary>
/// Операция редактирования сущности.
/// </summary>
public class UpdateEmployeeCommand : IRequest<Unit>
{
    public int Id { get; set; }
    
    public string DepartmentCode { get; set; }
    
    public string DepartmentFullName { get; set; }
    
    public string Surname { get; set; }
    
    public string FirstName { get; set; }
    
    public string? PatronymicName { get; set; }
    
    public string BirthDate { get; set; }
    
    public string DateOfEmployment { get; set; }
    
    public string Salary { get; set; }
}