namespace Core.Pagination;

public record PaginationRequest(string? Name, int? PageNumber = 1, int? PageSize = 10);

