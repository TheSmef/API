using API.Data.Context;
using API.Models.Entity;
using API.Models.Queries;
using API.Models.Response;
using API.Services.Handlers.Queries.Base;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Handlers.Queries.Employees
{
    public class GetEmployeesQueryHandler : IQueryHandler<GetEmployeesQuery, ICollection<EmployeeWithStatsResponse>>
    {
        private readonly DataContext _context;

        public GetEmployeesQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<ICollection<EmployeeWithStatsResponse>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var init = _context.Employees.AsQueryable();
            if (request.Post != null)
            {
                init = init.Where(x => x.Post == request.Post);
            }
            var response = init.Select(x => new EmployeeWithStatsResponse(
                x.Id,
                x.LastName,
                x.FirstName,
                x.MiddleName,
                x.Post,
                x.Shifts.Where(sh => sh.Date > DateOnly.FromDateTime(DateTime.Now.AddDays(-30)))
                     .Count(sh => x.Post == PostEnum.Tester ?
                     sh.Start <= TimeOnly.FromTimeSpan(TimeSpan.FromHours(9))
                     &&
                     sh.End >= TimeOnly.FromTimeSpan(TimeSpan.FromHours(21))
                     :
                     sh.Start <= TimeOnly.FromTimeSpan(TimeSpan.FromHours(9))
                     &&
                     sh.End >= TimeOnly.FromTimeSpan(TimeSpan.FromHours(18))),
                x.Shifts.Count(sh => sh.Date > DateOnly.FromDateTime(DateTime.Now.AddDays(-30)))
                    ));

            return await response.ToListAsync(cancellationToken);
        }
    }
}
