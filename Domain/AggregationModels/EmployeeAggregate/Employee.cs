using Domain.Models;

namespace Domain.AggregationModels.EmployeeAggregate;

/// <summary>
/// Работник.
/// </summary>
public class Employee : Entity
{
    public Employee(Department department, 
        FullName fullName, 
        BirthDate birthDate, 
        DateOfEmployment dateOfEmployment, 
        Salary salary)
    {
        Department = department;
        FullName = fullName;
        BirthDate = birthDate;
        DateOfEmployment = dateOfEmployment;
        Salary = salary;
    }
    
    private Employee() {} // EF Ctor
    
    public Department Department { get; }
    
    public FullName FullName { get; }
    
    public BirthDate BirthDate { get; set; }
    
    public DateOfEmployment DateOfEmployment { get; set; }

    public Salary Salary { get; set; }
}