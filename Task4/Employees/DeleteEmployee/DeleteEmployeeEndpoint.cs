namespace Task4.Employees.DeleteEmployee;

//public record class DeleteEmployeeRequest(int EmployeeId);
//public record class DeleteEmployeeResponse(bool IsSuccess);
public class DeleteEmployeeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/employee/{employeeId}", async (int employeeId, ISender sender) =>
        {
            var result = await sender.Send(new DeleteEmployeeCommand(employeeId));

            return Results.NoContent();
        })
        .WithName("DeleteEmployee")
        .Produces(StatusCodes.Status204NoContent)
        .WithDescription("Delete Employee")
        .WithSummary("Delete Employee");

        //TODO: Add validation for the request
        // Check produces for the endpoin
    }
}
