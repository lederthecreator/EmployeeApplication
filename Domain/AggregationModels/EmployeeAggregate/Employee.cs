using Domain.Models;

namespace Domain.AggregationModels.EmployeeAggregate;

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
    
    public Department Department { get; }
    
    public FullName FullName { get; }
    
    public BirthDate BirthDate { get; set; }
    
    public DateOfEmployment DateOfEmployment { get; set; }

    public Salary Salary { get; set; }
}