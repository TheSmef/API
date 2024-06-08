using API.Extensions.Enums;
using API.Models.Entity;

namespace API.Models.Response
{
    public record EmployeeWithStatsResponse(Guid Id,
            string LastName,
            string FirstName,
            string? MiddleName,
            PostEnum Post,
            int ViolationsFactor,
            int AttendanceFactor)
    {
        public string PostString => Post.GetStringValue();
        public int ComplianceFactor => AttendanceFactor - ViolationsFactor;
    }
}
