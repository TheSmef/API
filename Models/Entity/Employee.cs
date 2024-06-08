using API.Attributes;
using API.Models.Entity.Base;

namespace API.Models.Entity
{
    public sealed class Employee : BaseEntity
    {
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = null;
        public PostEnum Post { get; set; }
        public ICollection<Shift> Shifts { get; set; } = [];
    }

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
