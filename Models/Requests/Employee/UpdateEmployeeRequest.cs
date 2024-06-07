using API.Models.Entity;

namespace API.Models.Requests.Employee
{
    public record UpdateEmployeeRequest(
        Guid Id,
        string LastName,
        string FirstName,
        string? MiddleName,
        PostEnum Post)
    { }
}
