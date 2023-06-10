using Domain.AggregationModels.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.UnitOfWork;

namespace Persistence.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeContext _context;

    public EmployeeRepository(IUnitOfWork unitOfWork)
    {
        _context = unitOfWork.Context;
    }
    
    public async Task<Employee> CreateAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        await _context.AddAsync(employee, cancellationToken);

        return employee;
    }

    public Task<Employee> UpdateAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        if (_context.Attach(employee).State == EntityState.Detached)
        {
            throw new Exception("Internal error");
        }

        _context.Entry(employee).State = EntityState.Modified;

        return Task.FromResult(employee);
    }

    public void Delete(Employee employee)
    {
        if (_context.Attach(employee).State == EntityState.Detached)
        {
            throw new Exception("Internal error");
        }

        _context.Entry(employee).State = EntityState.Deleted;
        _context.Remove(employee);
    }

    public async Task<Employee?> FindByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.FindAsync<Employee>(id);
    }

    public IEnumerable<Employee> GetAll()
    {
        return _context.Employees.ToList();
    }
}