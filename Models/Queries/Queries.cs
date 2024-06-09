using API.Models.Entity;
using API.Models.Queries.Base;
using API.Models.Response;

namespace API.Models.Queries
{
    /// <summary>
    /// <inheritdoc cref="IQuery{T}"/>
    /// </summary>
    /// <param name="Post">Должность сотрудника</param>
    public sealed record GetEmployeesQuery(PostEnum? Post) : IQuery<ICollection<EmployeeWithStatsResponse>>;
}
