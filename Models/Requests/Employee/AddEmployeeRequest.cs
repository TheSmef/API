using API.Models.Entity;

namespace API.Models.Requests.Employee
{
    public record AddEmployeeRequest(
        string LastName,
        string FirstName,
        string? MiddleName,
        PostEnum Post)
    { }
}
