using API.Models.Entity;

namespace API.Models.Requests.Employee
{
    public record DeleteEmployeeRequest(
        Guid Id)
    { }
}
