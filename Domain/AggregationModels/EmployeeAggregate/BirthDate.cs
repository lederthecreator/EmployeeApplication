using System.Globalization;
using Domain.Models;

namespace Domain.AggregationModels.EmployeeAggregate;

public class BirthDate : ValueObject
{
    public DateOnly Value { get; private set; }

    public BirthDate(string birthDate)
    {
        var cultureInfo = new CultureInfo("ru-RU");
        if (!DateOnly.TryParse(birthDate, cultureInfo, out var parsedValue))
        {
            throw new Exception("Не удалось получить дату из строкового представления");
        }

        Value = parsedValue;
    }

    public BirthDate(DateOnly birthDate)
    {
        if (birthDate.Year < 1900)
        {
            throw new Exception("Некорректная дата");
        }

        Value = birthDate;
    }

    public BirthDate(BirthDate other)
    {
        Value = other.Value;
    }

    public void SetBirthDate(DateOnly birthDate)
    {
        Value = birthDate;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}