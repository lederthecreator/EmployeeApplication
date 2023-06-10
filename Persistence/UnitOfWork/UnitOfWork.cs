using Persistence.Context;

namespace Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly EmployeeContext _context;
    private bool _isDisposed;

    public UnitOfWork(EmployeeContext context)
    {
        _context = context;
    }

    public EmployeeContext Context
    {
        get
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }

            return _context;
        }
    }
    
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        if (_isDisposed)
        {
            throw new ObjectDisposedException(GetType().FullName);
        }
        
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed)
        {
            return;
        }

        if (disposing)
        {
            _context.Dispose();
        }

        _isDisposed = true;
    }
}