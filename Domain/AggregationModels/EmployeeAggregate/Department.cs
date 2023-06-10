using Domain.Models;

namespace Domain.AggregationModels.EmployeeAggregate;

public class Department : ValueObject
{
    public string Code { get; private set; }
    
    public string FullName { get; private set; }

    public Department(string code, string fullName)
    {
        if (string.IsNullOrEmpty(code) || code.Length != 3)
        {
            throw new Exception("Код не может быть пустым или длиной больше 3 символов");
        }
        
        if (string.IsNullOrEmpty(fullName) || !fullName.All(x => char.IsWhiteSpace(x) || char.IsLetter(x)))
        {
            throw new Exception("Наименование учреждения не может быть пустым или содержать некорректные символы");
        }
        
        Code = code;
        FullName = fullName;
    }

    public Department(Department other)
    {
        Code = other.Code;
        FullName = other.FullName;
    }

    public void SetCode(string code)
    {
        if (string.IsNullOrEmpty(code) || code.Length != 3)
        {
            throw new Exception("Код не может быть пустым или длиной больше 3 символов");
        }

        Code = code;
    }

    public void SetFullName(string fullName)
    {
        if (string.IsNullOrEmpty(fullName) || !fullName.All(x => char.IsWhiteSpace(x) || char.IsLetter(x)))
        {
            throw new Exception("Наименование учреждения не может быть пустым или содержать некорректные символы");
        }

        FullName = fullName;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
        yield return FullName;
    }
}