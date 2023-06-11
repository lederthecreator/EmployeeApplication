namespace Domain.AggregationModels.EmployeeAggregate;

/// <summary>
/// Репозиторий для работы с сущностью Employee.
/// </summary>
public interface IEmployeeRepository
{
    /// <summary>
    /// Создать запись.
    /// </summary>
    /// <param name="employee">Данные записи</param>
    /// <param name="cancellationToken">Отмена операции</param>
    /// <returns>Созданная сущность</returns>
    Task<Employee> CreateAsync(Employee employee, CancellationToken cancellationToken = default);

    /// <summary>
    /// Редактировать запись.
    /// </summary>
    /// <param name="employee">Данные записи</param>
    /// <param name="cancellationToken">Отмена операции</param>
    /// <returns>Отредактированная сущность</returns>
    Task<Employee> UpdateAsync(Employee employee, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удаление записи.
    /// </summary>
    /// <param name="employee">Удаляемая сущность</param>
    void Delete(Employee employee);

    /// <summary>
    /// Получить запись по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор записи</param>
    /// <param name="cancellationToken">Отмена операции</param>
    /// <returns>Найденная сущность</returns>
    Task<Employee?> FindByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить все записи.
    /// </summary>
    /// <returns>Список всех записей</returns>
    public IEnumerable<Employee> GetAll();
}