using API.Models.Entity;
using API.Models.Queries.Base;
using API.Models.Response;

namespace API.Models.Queries
{
    public sealed record GetEmployeesQuery(PostEnum? Post) : IQuery<ICollection<EmployeeWithStatsResponse>>;
}
