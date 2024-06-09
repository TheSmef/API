using API.Models.Entity;

namespace API.Models.Requests.Employee
{
    /// <summary>
    /// Модель-запрос на удаление сотрудника
    /// </summary>
    /// <param name="Id">Идентификатор сотрудника</param>
    public record DeleteEmployeeRequest(
        Guid Id)
    { }
}
