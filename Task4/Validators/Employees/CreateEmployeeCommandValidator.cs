using FluentValidation;
using Task4.Employees.CreateEmployee;

namespace Task4.Validators.Employees;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(x => x.Employee)
            .NotNull()
            .WithMessage("Employee cannot be null");

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
