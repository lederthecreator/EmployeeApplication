using Domain.Models;

namespace Domain.AggregationModels.EmployeeAggregate;

/// <summary>
/// Полное имя.
/// </summary>
public class FullName : ValueObject
{
    /// <summary>
    /// Фамилия.
    /// </summary>
    public string Surname { get; private set; }
    
    /// <summary>
    /// Имя.
    /// </summary>
    public string FirstName { get; private set; }
    
    /// <summary>
    /// Отчество (необязательно).
    /// </summary>
    public string? PatronymicName { get; set; }

    public FullName(string surname, string firstName)
    {
        if (string.IsNullOrEmpty(surname) || surname.Any(x => !char.IsLetter(x)))
        {
            throw new Exception("Фамилия содержит в себе некорректные символы");
        }

        if (string.IsNullOrEmpty(firstName) || firstName.Any(x => !char.IsLetter(x)))
        {
            throw new Exception("Имя содержит в себе некорректные символы");
        }

        Surname = surname;
        FirstName = firstName;
    }

    public FullName(string surname, string firstName, string patronymicName)
    {
        if (string.IsNullOrEmpty(surname) || surname.Any(x => !char.IsLetter(x)))
        {
            throw new Exception("Фамилия содержит в себе некорректные символы");
        }

        if (string.IsNullOrEmpty(firstName) || firstName.Any(x => !char.IsLetter(x)))
        {
            throw new Exception("Имя содержит в себе некорректные символы");
        }

        if (string.IsNullOrEmpty(patronymicName) || patronymicName.Any(x => !char.IsLetter(x)))
        {
            throw new Exception("Отчество содержит в себе некорректные символы");
        }

        Surname = surname;
        FirstName = firstName;
        PatronymicName = patronymicName;
    }

    public FullName(FullName other)
    {
        Surname = other.Surname;
        FirstName = other.FirstName;
        PatronymicName = other.PatronymicName;
    }

    public void SetSurname(string surname)
    {
        if (string.IsNullOrEmpty(surname) || surname.Any(x => !char.IsLetter(x)))
        {
            throw new Exception("Фамилия содержит в себе некорректные символы");
        }

        Surname = surname;
    }

    public void SetFirstName(string firstName)
    {
        if (string.IsNullOrEmpty(firstName) || firstName.Any(x => !char.IsLetter(x)))
        {
            throw new Exception("Имя содержит в себе некорректные символы");
        }

        FirstName = firstName;
    }

    public void SetPatronymicName(string patronymicName)
    {
        if (string.IsNullOrEmpty(patronymicName) || patronymicName.Any(x => !char.IsLetter(x)))
        {
            throw new Exception("Отчество содержит в себе некорректные символы");
        }

        PatronymicName = patronymicName;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Surname;
        yield return FirstName;
    }
}