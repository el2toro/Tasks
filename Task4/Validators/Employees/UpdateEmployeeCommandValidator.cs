using Task4.Employees.UpdateEmployee;

namespace Task4.Validators.Employees;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(x => x.Employee)
            .NotNull()
            .WithMessage("Employee cannot be null");

        RuleFor(x => x.Employee.Id)
            .NotEmpty()
            .WithMessage("Employee Id cannot be empty")
            .GreaterThan(0)
            .WithMessage("Employee Id must be greater than 0");

        RuleFor(x => x.Employee.Name)
           .NotEmpty()
           .WithMessage("Name cannot be empty");

        RuleFor(x => x.Employee.Surname)
            .NotEmpty()
            .WithMessage("Surname cannot be empty");

        RuleFor(x => x.Employee.DateOfBirth)
            .NotEmpty()
            .WithMessage("DateOfBirth cannot be empty");

        RuleFor(x => x.Employee.EmploymentDate)
            .NotEmpty()
            .WithMessage("DateOfBirth cannot be empty");

        RuleFor(x => x.Employee.Department)
            .IsInEnum()
            .WithMessage("Department is invalid");

        RuleFor(x => x.Employee.Position)
           .IsInEnum()
           .WithMessage("Position is invalid");
    }
}
