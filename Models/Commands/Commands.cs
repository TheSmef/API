using API.Models.Commands.Base;
using API.Models.Entity;
using API.Models.Response;

namespace API.Models.Commands
{
    public sealed record AddEmployeeCommand(
        string LastName,
        string FirstName,
        string? MiddleName,
        PostEnum Post) : ICommand<EmployeeResponse>;
    public sealed record UpdateEmplyeeCommand(
        Guid Id,
        string LastName,
        string FirstName,
        string? MiddleName,
        PostEnum Post) : ICommand<EmployeeResponse>;
    public sealed record DeleteEmployeeCommand(Guid Id) : ICommand;
    public sealed record StartShiftCommand(Guid Id, DateOnly Date, TimeOnly Time) : ICommand;
    public sealed record EndShiftCommand(Guid Id, TimeOnly Time) : ICommand;
}