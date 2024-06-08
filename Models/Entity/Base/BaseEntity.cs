namespace API.Models.Entity.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = new Guid();
    }
}
