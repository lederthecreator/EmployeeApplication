using Persistence.Context;

namespace Persistence.UnitOfWork;

public interface IUnitOfWork
{
    EmployeeContext Context { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}