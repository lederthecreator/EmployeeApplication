using System.Globalization;
using Domain.Models;

namespace Domain.AggregationModels.EmployeeAggregate;

/// <summary>
/// Заработная плата.
/// </summary>
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

    public Salary(string salary)
    {
        if (string.IsNullOrEmpty(salary))
        {
            throw new Exception("Зарплата не может быть пустой");
        }
        
        if (!decimal.TryParse(salary, CultureInfo.CurrentCulture, out var parsedSalary) || parsedSalary <= 0)
        {
            throw new Exception("Зарплата не может быть меньше или равной нулю");
        }

        Value = parsedSalary;
    }

    public Salary(Salary other)
    {
        Value = other.Value;
    }
    
    private Salary() {} // EF Ctor

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