namespace Task4.Employees.GetEmployees;

public record GetEmployeesQuery
    (string? Name, int? PageNumber = 1, int? PageSize = 10) : IQuery<GetEmployeesResult>;
public record GetEmployeesResult(PaginatedResult<EmployeeDto> PaginatedResult);

public class GetEmployeesHandler(IEmployeeRepository employeeRepository, ILogger<GetEmployeesHandler> logger)
    : IQueryHandler<GetEmployeesQuery, GetEmployeesResult>
{
    public async Task<GetEmployeesResult> Handle(GetEmployeesQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation($"GetEmployeesHandler called with query: {query}");

        PaginationRequest paginationRequest = query.Adapt<PaginationRequest>();
        PaginatedResult<Employee> paginatedResult = await employeeRepository.GetEmployeesAsync(paginationRequest, cancellationToken);
        PaginatedResult<EmployeeDto> result = paginatedResult.Adapt<PaginatedResult<EmployeeDto>>();

        return new GetEmployeesResult(result);
    }
}
