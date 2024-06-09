using API.Extensions.Enums;
using API.Models.Entity;

namespace API.Models.Response
{
    /// <summary>
    /// Модель-ответ с данными сотрудника и его статистикой смен
    /// </summary>
    /// <param name="Id">Идентификатор сотрудника</param>
    /// <param name="LastName">Фамилия сотрудника</param>
    /// <param name="FirstName">Имя сотрудника</param>
    /// <param name="MiddleName">Отчество сотрудника</param>
    /// <param name="Post">Должность сотрудника</param>
    /// <param name="ViolationsFactor">Количество замечаний</param>
    /// <param name="AttendanceFactor">Количество посещений</param>
    public record EmployeeWithStatsResponse(Guid Id,
            string LastName,
            string FirstName,
            string? MiddleName,
            PostEnum Post,
            int ViolationsFactor,
            int AttendanceFactor)
    {
        /// <summary>
        /// Должность сотрудника в виде строки
        /// </summary>
        public string PostString => Post.GetStringValue();
        /// <summary>
        /// Количество смен без замечаний
        /// </summary>
        public int ComplianceFactor => AttendanceFactor - ViolationsFactor;
    }
}
