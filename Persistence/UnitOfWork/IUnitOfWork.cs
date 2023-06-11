using Persistence.Context;

namespace Persistence.UnitOfWork;

/// <summary>
/// Паттерн UnitOfWork для работы с БД.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Контекст БД.
    /// </summary>
    EmployeeContext Context { get; }

    /// <summary>
    /// Сохранить изменения.
    /// </summary>
    /// <param name="cancellationToken">Отмена операции</param>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}