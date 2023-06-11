namespace EmployeeApi.Dtos;

/// <summary>
/// DTO сущности.
/// </summary>
public class EmployeeDto
{
    /// <summary>
    /// Идентификатор записи.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Наименование учреждения.
    /// </summary>
    public string DepartmentName { get; set; }
    
    /// <summary>
    /// Код учреждения.
    /// </summary>
    public string DepartmentCode { get; set; }
    
    /// <summary>
    /// Фамилия.
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// Отчество (необязательно).
    /// </summary>
    public string PatronymicName { get; set; }
    
    /// <summary>
    /// Дата рождения.
    /// </summary>
    public string BirthDate { get; set; }
    
    /// <summary>
    ///  Дата устройства на работу.
    /// </summary>
    public string DateOfEmployee { get; set; }
    
    /// <summary>
    /// Заработная плата.
    /// </summary>
    public string Salary { get; set; }
}