namespace Task4.Employees.GetEmployeeById;

//public record class GetEmployeeByIdRequest(int Id);
public record class GetEmployeeByIdResponse(EmployeeDto Employee);

public class GetEmployeeByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/employee/{employeeId}", async (int employeeId, ISender sender) =>
        {
            var result = await sender.Send(new GetEmployeeByIdQuery(employeeId));
            var response = result.Employee.Adapt<EmployeeDto>();

            return Results.Ok(new GetEmployeeByIdResponse(response));
        })
        .WithName("GetEmployeeById")
        .Produces<GetEmployeeByIdResponse>(StatusCodes.Status200OK)
        .WithDescription("Get Employee By Id")
        .WithSummary("Get Employee By Id");
    }
}
