using API.Attributes;
using API.Models.Entity.Base;

namespace API.Models.Entity
{
    /// <summary>
    /// Сущность сотрудника
    /// </summary>
    public sealed class Employee : BaseEntity
    {
        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string LastName { get; set; } = string.Empty;
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string FirstName { get; set; } = string.Empty;
        /// <summary>
        /// Отчество сотрудника
        /// </summary>
        public string? MiddleName { get; set; } = null;
        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public PostEnum Post { get; set; }
        /// <summary>
        /// Навигационное свойство для смен
        /// </summary>
        public ICollection<Shift> Shifts { get; set; } = [];
    }

    /// <summary>
    /// Enum для должностей сотрудников
    /// </summary>
    public enum PostEnum
    {
        [StringValue("Менеджер")]
        Manager = 0,
        [StringValue("Инженер")]
        Engineer = 1,
        [StringValue("Тестировщик свечей")]
        Tester = 2,
    }
}
