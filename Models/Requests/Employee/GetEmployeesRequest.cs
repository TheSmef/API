using API.Models.Entity;

namespace API.Models.Requests.Employee
{
    /// <summary>
    /// Модель-запрос для получение данных сотрудников
    /// </summary>
    /// <param name="PostEnum">Должность сотрудника</param>
    public record GetEmployeesRequest(
        PostEnum? PostEnum)
    { }
}
