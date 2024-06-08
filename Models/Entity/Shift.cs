using API.Models.Entity.Base;

namespace API.Models.Entity
{
    public class Shift : BaseEntity
    {
        public TimeOnly Start { get; set; }
        public TimeOnly? End { get; set; } = null;
        public Guid EmployeeId { get; set; } = new Guid();
        public virtual Employee Employee { get; set; } = default!;
        public DateOnly Date { get; set; }
        public TimeSpan WorkTime => End == null ? TimeSpan.Zero : (End - Start).Value;
    }
}
