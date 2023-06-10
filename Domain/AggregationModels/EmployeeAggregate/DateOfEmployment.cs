using System.Globalization;
using Domain.Models;

namespace Domain.AggregationModels.EmployeeAggregate;

public class DateOfEmployment : ValueObject
{
    public DateOnly Value { get; private set; }

    public DateOfEmployment(string date)
    {
        var cultureInfo = new CultureInfo("ru-RU");
        if (!DateOnly.TryParse(date, cultureInfo, out var parsedValue))
        {
            throw new Exception("Не удалось распознать дату");
        }

        Value = parsedValue;
    }

    public DateOfEmployment(DateOfEmployment other)
    {
        Value = other.Value;
    }

    public void SetDateOfEmployment(DateOnly date)
    {
        Value = date;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}