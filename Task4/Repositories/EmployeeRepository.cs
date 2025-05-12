using Task4.Contexts;
using Task4.Exceptions;
using Task4.Extensions;

namespace Task4.Repositories;
public class EmployeeRepository(EmployeeDbContext dbContext) : IEmployeeRepository
{
    public async Task CreateEmployeeAsync(Employee employee, CancellationToken cancellationToken)
    {
        dbContext.Employees.Add(employee);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteEmployeeAsync(int id, CancellationToken cancellationToken)
    {
        Employee employee = await dbContext.Employees.FindAsync(id) ??
            throw new EmployeeNotFoundException(id);

        dbContext.Employees.Remove(employee);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Employee> GetEmployeeByIdAsync(int id, CancellationToken cancellationToken)
    {
        Employee employee = await dbContext.Employees.FindAsync(id, cancellationToken) ??
            throw new EmployeeNotFoundException(id);

        return employee;
    }

    public async Task<PaginatedResult<Employee>> GetEmployeesAsync
        (PaginationRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Employee> query = dbContext.Employees.AsQueryable();

        if (!string.IsNullOrEmpty(request?.Name))
        {
            query = query.Where(e => e.Name.Contains(request.Name.Trim()) || e.Surname.Contains(request.Name.Trim()));
        }

        query = query.OrderBy(e => e.Position);

        var pagedResult = await query.ToPagedListAsync(request?.PageNumber ?? 1, request?.PageSize ?? 10, cancellationToken);

        (int pageIndex, int itemsPerPage, int totalCount, IEnumerable<Employee> employees) = pagedResult;

        return new PaginatedResult<Employee>(pageIndex, itemsPerPage, totalCount, employees);
    }

    public async Task UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken)
    {
        Employee existingEmployee = await dbContext.Employees.FindAsync(employee.Id) ??
           throw new EmployeeNotFoundException(employee.Id);

        existingEmployee.Name = employee.Name;
        existingEmployee.Surname = employee.Surname;
        existingEmployee.Salary = employee.Salary;
        existingEmployee.Position = employee.Position;
        existingEmployee.DateOfBirth = employee.DateOfBirth;
        existingEmployee.EmploymentDate = employee.EmploymentDate;
        existingEmployee.Department = employee.Department;

        dbContext.Update(existingEmployee);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
