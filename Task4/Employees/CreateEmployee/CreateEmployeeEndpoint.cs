namespace Task4.Employees.CreateEmployee;

public record CreateEmployeeRequest(EmployeeDto Employee);
public record CreateEmployeeResponse(EmployeeDto Employee);
public class CreateEmployeeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/employee", async (CreateEmployeeRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateEmployeeCommand>();
            var result = await sender.Send(command);
            var response = request.Employee.Adapt<EmployeeDto>();

            return Results.Created($"/employee/{response}", new CreateEmployeeResponse(response));
        })
        .WithName("CreateEmployee")
        .Produces<CreateEmployeeResponse>(StatusCodes.Status201Created)
        .WithDescription("Create Employee")
        .WithSummary("Create Employee");
    }
}
