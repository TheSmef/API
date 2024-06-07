using API.Models.Entity;
using API.Models.Queries.Base;
using API.Models.Response;

namespace API.Models.Queries
{
    public sealed record GetEmployeeQuery(PostEnum Post) : IQuery<ICollection<EmployeeWithStatsResponse>>;
}
