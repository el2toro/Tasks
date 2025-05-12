namespace Task4.Exceptions;

public class EmployeeNotFoundException : NotFoundException
{
    public EmployeeNotFoundException(int userId) : base("Employee", userId)
    {
    }
}

