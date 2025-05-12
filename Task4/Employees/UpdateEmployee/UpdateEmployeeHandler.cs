namespace Task4.Employees.UpdateEmployee;

public record class UpdateEmployeeCommand(EmployeeDto Employee) : ICommand<UpdateEmployeeResult>;
public record class UpdateEmployeeResult(bool IsSuccess, EmployeeDto Employee);



public class UpdateEmployeeHandler(IEmployeeRepository employeeRepository, ILogger<UpdateEmployeeHandler> logger)
    : ICommandHandler<UpdateEmployeeCommand, UpdateEmployeeResult>
{
    public async Task<UpdateEmployeeResult> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation($"UpdateEmployeeHandler called with EmployeeDto: {command.Employee}");

        Employee employee = command.Employee.Adapt<Employee>();
        await employeeRepository.UpdateEmployeeAsync(employee, cancellationToken);

        return new UpdateEmployeeResult(true, command.Employee);
    }
}
