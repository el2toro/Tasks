namespace Task4.Dtos;

public class EmployeeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public Position Position { get; set; }
    public Department Department { get; set; } = default!;
    public decimal Salary { get; set; }
    public string DateOfBirth { get; set; } = default!;
    public string EmploymentDate { get; set; } = default!;
}
