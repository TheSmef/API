using API.Models.Entity.Base;

namespace API.Models.Entity
{
    /// <summary>
    /// Сущность для смен
    /// </summary>
    public class Shift : BaseEntity
    {
        /// <summary>
        /// Время старта смены
        /// </summary>
        public TimeOnly Start { get; set; }
        /// <summary>
        /// Время конца смены
        /// </summary>
        public TimeOnly? End { get; set; } = null;
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public Guid EmployeeId { get; set; } = new Guid();
        /// <summary>
        /// Навигационное свойство для сотрудника
        /// </summary>
        public virtual Employee Employee { get; set; } = default!;
        /// <summary>
        /// Дата смены
        /// </summary>
        public DateOnly Date { get; set; }
        /// <summary>
        /// Расчётное поле для отработанного времени
        /// </summary>
        public TimeSpan WorkTime => End == null ? TimeSpan.Zero : (End - Start).Value;
    }
}
