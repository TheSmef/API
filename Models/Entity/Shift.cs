using API.Models.Entity.Base;

namespace API.Models.Entity
{
    public class Shift : BaseEntity
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public int WorkTime { get; set; } = 0;
        public Employee Employee { get; set; } = new Employee();
    }
}
