using API.Models.Entity;

namespace API.Models.Requests.Employee
{
    /// <summary>
    /// Модель-запрос для обновления данных сотрудника
    /// </summary>
    /// <param name="Id">Идентификатор сотрудника</param>
    /// <param name="LastName">Фамилия сотрудника</param>
    /// <param name="FirstName">Имя сотрудника</param>
    /// <param name="MiddleName">Отчество сотрудника</param>
    /// <param name="Post">Должность сотрудника</param>
    public record UpdateEmployeeRequest(
        Guid Id,
        string LastName,
        string FirstName,
        string? MiddleName,
        PostEnum? Post = null)
    { }
}
