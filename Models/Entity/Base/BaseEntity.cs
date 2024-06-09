namespace API.Models.Entity.Base
{
    /// <summary>
    /// Класс базовой сущности
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public Guid Id { get; set; } = new Guid();
    }
}
