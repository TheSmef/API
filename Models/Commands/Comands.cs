using API.Models.Commands.Base;
using API.Models.Response;

namespace API.Models.Commands
{
    public sealed record AddEmployeeCommand() : ICommand<EmployeeResponse>;
    public sealed record UpdateEmplyeeCommand() : ICommand<EmployeeResponse>;
    public sealed record DeleteEmployeeCommand(Guid Id) : ICommand;
    public sealed record StartShiftCommand(Guid Id, DateTime DateTime) : ICommand;
    public sealed record EndShiftCommand(Guid Id, DateTime DateTime) : ICommand;
}