using Domain.Models;

namespace Domain.AggregationModels.EmployeeAggregate;

public class Salary : ValueObject
{
    public decimal Value { get; private set; }

    public Salary(decimal salary)
    {
        if (salary <= 0m)
        {
            throw new Exception("Зарплата не может быть меньше или равной нулю");
        }

        Value = salary;
    }

    public Salary(Salary other)
    {
        Value = other.Value;
    }

    public void SetSalary(decimal salary)
    {
        if (salary <= 0m)
        {
            throw new Exception("Зарплата не может быть меньше или равной нулю");
        }

        Value = salary;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}