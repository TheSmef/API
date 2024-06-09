using API.Extensions.Enums;
using API.Models.Entity;

namespace API.Models.Response
{
    /// <summary>
    /// Модель-ответ с данными сотрудника
    /// </summary>
    /// <param name="Id">Идентификатор сотрудника</param>
    /// <param name="LastName">Фамилия сотрудника</param>
    /// <param name="FirstName">Имя сотрудника</param>
    /// <param name="MiddleName">Отчество сотрудника</param>
    /// <param name="Post">Должность сотрудника</param>
    public record EmployeeResponse(Guid Id,
            string LastName,
            string FirstName,
            string? MiddleName,
            PostEnum Post)
    {
        /// <summary>
        /// Должность сотрудника в виде строки
        /// </summary>
        public string PostString => Post.GetStringValue();
    }
}
