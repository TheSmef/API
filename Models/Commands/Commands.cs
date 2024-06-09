using API.Models.Commands.Base;
using API.Models.Entity;
using API.Models.Response;

namespace API.Models.Commands
{
    /// <summary>
    /// Команда для добавления сотрудника <see cref="Employee"/>
    /// </summary>
    /// <param name="LastName">Фамилия сотрудника</param>
    /// <param name="FirstName">Имя сотрудника</param>
    /// <param name="MiddleName">Отчество сотрудника</param>
    /// <param name="Post">Должность сотрудника</param>
    public sealed record AddEmployeeCommand(
        string LastName,
        string FirstName,
        string? MiddleName,
        PostEnum? Post = null) : ICommand<EmployeeResponse>;
    /// <summary>
    /// Команда для обновления данных сотрудника <see cref="Employee"/>
    /// </summary>
    /// <param name="Id">Идентификатор сотрудника</param>
    /// <param name="LastName">Фамилия сотрудника</param>
    /// <param name="FirstName">Имя сотрудника</param>
    /// <param name="MiddleName">Отчество сотрудника</param>
    /// <param name="Post">Должность сотрудника</param>
    public sealed record UpdateEmployeeCommand(
        Guid Id,
        string LastName,
        string FirstName,
        string? MiddleName,
        PostEnum? Post = null) : ICommand<EmployeeResponse>;
    /// <summary>
    /// Команда для удаления сотрудника <see cref="Employee"/>
    /// </summary>
    /// <param name="Id"></param>
    public sealed record DeleteEmployeeCommand(Guid Id) : ICommand;
    /// <summary>
    /// Команда для начала смены <see cref="Shift"/>
    /// </summary>
    /// <param name="Id">Идентификатор сотрудника <see cref="Employee"/></param>
    /// <param name="Date">Дата начала смены</param>
    /// <param name="Time">Время начала смены</param>
    public sealed record StartShiftCommand(Guid Id, DateOnly Date, TimeOnly Time) : ICommand;
    /// <summary>
    /// Команда для окончания смены <see cref="Shift"/>
    /// </summary>
    /// <param name="Id">Идентификатор сотрудника <see cref="Employee"/></param>
    /// <param name="Time">Время конца смены</param>
    public sealed record EndShiftCommand(Guid Id, TimeOnly Time) : ICommand;
}