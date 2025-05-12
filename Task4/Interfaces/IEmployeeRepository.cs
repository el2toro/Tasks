using Core.Pagination;

namespace Task4.Interfaces;

public interface IEmployeeRepository
{
    Task<Employee> GetEmployeeByIdAsync(int id, CancellationToken cancellationToken);
    Task<PaginatedResult<Employee>> GetEmployeesAsync(PaginationRequest paginationRequest, CancellationToken cancellationToken);
    Task CreateEmployeeAsync(Employee employee, CancellationToken cancellationToken);
    Task UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken);
    Task DeleteEmployeeAsync(int id, CancellationToken cancellationToken);
}
