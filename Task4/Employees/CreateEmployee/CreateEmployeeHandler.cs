namespace Task4.Employees.CreateEmployee;

public record CreateEmployeeCommand(EmployeeDto Employee) : ICommand<CreateEmployeeResult>;
public record CreateEmployeeResult(bool IsSuccess);

public class CreateEmployeeHandler(IEmployeeRepository employeeRepository, ILogger<CreateEmployeeHandler> logger)
    : ICommandHandler<CreateEmployeeCommand, CreateEmployeeResult>
{
    public async Task<CreateEmployeeResult> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation($"CreateEmployeeHandlere with EmployeeDto: {command.Employee}");

        Employee employee = command.Employee.Adapt<Employee>();
        await employeeRepository.CreateEmployeeAsync(employee, cancellationToken);

        return new CreateEmployeeResult(true);
    }
}
