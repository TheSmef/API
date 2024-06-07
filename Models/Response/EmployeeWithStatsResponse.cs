using API.Extensions.Enums;
using API.Models.Entity;

namespace API.Models.Response
{
    public record EmployeeWithStatsResponse(Guid Id,
            string LastName,
            string FirstName,
            string MiddleName,
            PostEnum Post,
            int ViolationsFactor,
            int ComplianceFactor)
    {
        public string PostString => Post.GetStringValue();
    }
}
