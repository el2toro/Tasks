namespace Task4.Employees.UpdateEmployee;

public record class UpdateEmployeeRequest(EmployeeDto Employee);
public record class UpdateEmployeeResponse(EmployeeDto Employee);

public class UpdateEmployeeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/employee", async (UpdateEmployeeRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateEmployeeCommand>();
            var result = await sender.Send(command);
            var response = result.Employee.Adapt<EmployeeDto>();

            return Results.Ok(new UpdateEmployeeResponse(response));
        })
        .WithName("UpdateEmployee")
        .Produces<UpdateEmployeeResponse>(StatusCodes.Status200OK)
        .WithDescription("Update Employee")
        .WithSummary("Update Employee");
    }
}
