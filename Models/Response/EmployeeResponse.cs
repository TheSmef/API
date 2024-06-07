using API.Extensions.Enums;
using API.Models.Entity;

namespace API.Models.Response
{
    public record EmployeeResponse(Guid Id,
            string LastName,
            string FirstName,
            string MiddleName,
            PostEnum Post)
    {
        public string PostString => Post.GetStringValue();
    }
}
