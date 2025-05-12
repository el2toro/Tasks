namespace Task4.Employees.GetEmployeeById;

public record class GetEmployeeByIdQuery(int Id) : IQuery<GetEmployeeByIdResult>;
public record class GetEmployeeByIdResult(EmployeeDto Employee);

public class GetEmployeeByIdQueryValidator : AbstractValidator<GetEmployeeByIdQuery>
{
    public GetEmployeeByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id cannot be empty.")
            .GreaterThan(0)
            .WithMessage("Id must be greater than 0.");
    }
}

public class GetEmployeeByIdHandler(IEmployeeRepository employeeRepository, ILogger<GetEmployeeByIdHandler> logger)
    : IQueryHandler<GetEmployeeByIdQuery, GetEmployeeByIdResult>
{
    public async Task<GetEmployeeByIdResult> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation($"GetEmployeeByIdHandler called with Id: {query.Id}");

        Employee employee = await employeeRepository.GetEmployeeByIdAsync(query.Id, cancellationToken);
        return new GetEmployeeByIdResult(employee.Adapt<EmployeeDto>());
    }
}
