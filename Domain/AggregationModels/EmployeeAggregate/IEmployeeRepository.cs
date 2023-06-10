namespace Domain.AggregationModels.EmployeeAggregate;

public interface IEmployeeRepository
{
    Task<Employee> CreateAsync(Employee employee, CancellationToken cancellationToken = default);

    Task<Employee> UpdateAsync(Employee employee, CancellationToken cancellationToken = default);

    void Delete(Employee employee);

    Task<Employee?> FindByIdAsync(int id, CancellationToken cancellationToken = default);

    public IEnumerable<Employee> GetAll();
}