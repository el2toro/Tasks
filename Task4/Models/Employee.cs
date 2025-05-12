namespace Task4.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public Position Position { get; set; }
    public Department Department { get; set; }
    public decimal Salary { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public DateOnly EmploymentDate { get; set; }
}

public enum Position
{
    Manager = 1,
    Developer = 2,
    Designer = 3,
    Tester = 4,
    HR = 5,
    MarketingSpecialist = 6,
    FinanceAnalyst = 7
}

public enum Department
{
    IT = 1,
    HR = 2,
    Sales = 3,
    Marketing = 4,
    Finance = 5
}
