namespace Task4.Employees.GetEmployees;

public record GetEmployeesRequest(string? Name, int? PageNumber = 1, int? PageSize = 10);
public record GetEmployeesResponse(PaginatedResult<EmployeeDto> PaginatedResult);

public class GetEmployeesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/employees", async ([AsParameters] GetEmployeesRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetEmployeesQuery>();
            var result = await sender.Send(query);

            return Results.Ok(new GetEmployeesResponse(result.PaginatedResult));
        })
        .WithName("GetEmployees")
        .Produces<GetEmployeesResponse>(StatusCodes.Status200OK)
        .WithDescription("Get Employees")
        .WithSummary("Get Employees");
    }
}
