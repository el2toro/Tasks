namespace Task4.Employees.DeleteEmployee;

public record class DeleteEmployeeCommand(int EmployeeId) : ICommand<DeleteEmployeeResult>;
public record class DeleteEmployeeResult(bool IsSuccess);

public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeCommandValidator()
    {
        RuleFor(x => x.EmployeeId)
            .NotEmpty()
            .WithMessage("EmployeeId cannot be empty.")
            .GreaterThan(0)
            .WithMessage("EmployeeId must be greater than 0.");
    }
}

public class DeleteEmployeeHandler(IEmployeeRepository employeeRepository, ILogger<DeleteEmployeeHandler> logger)
    : ICommandHandler<DeleteEmployeeCommand, DeleteEmployeeResult>
{
    public async Task<DeleteEmployeeResult> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation($"DeleteEmployeeHandler called with EmployeeId: {command.EmployeeId}");

        await employeeRepository.DeleteEmployeeAsync(command.EmployeeId, cancellationToken);
        return new DeleteEmployeeResult(true);
    }
}
