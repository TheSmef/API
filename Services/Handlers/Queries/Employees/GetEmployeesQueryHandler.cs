using API.Data.Context;
using API.Models.Entity;
using API.Models.Queries;
using API.Models.Response;
using API.Services.Handlers.Queries.Base;
using API.Utility.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Handlers.Queries.Employees
{
    /// <summary>
    /// Класс-обработчик запроса на данные сотрудников
    /// </summary>
    public class GetEmployeesQueryHandler : IQueryHandler<GetEmployeesQuery, ICollection<EmployeeWithStatsResponse>>
    {
        /// <summary>
        /// Контекст базы данных
        /// </summary>
        private readonly DataContext _context;
        /// <summary>
        /// Конструктор обработчика
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public GetEmployeesQueryHandler(DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Метод-обработчик запроса на данные сотрудников
        /// </summary>
        /// <param name="request">Модель-запрос</param>
        /// <param name="cancellationToken">Токены отмены операции</param>
        /// <returns><<see cref="Result"/> и необходимый тип описанный в запросе <see cref="GetEmployeesQuery"/>/returns>
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
                     .Count(sh => (x.Post == PostEnum.Tester ?
                     sh.Start > TimeOnly.FromTimeSpan(TimeSpan.FromHours(9))
                     ||
                     sh.End < TimeOnly.FromTimeSpan(TimeSpan.FromHours(21))
                     :
                     sh.Start > TimeOnly.FromTimeSpan(TimeSpan.FromHours(9))
                     ||
                     sh.End < TimeOnly.FromTimeSpan(TimeSpan.FromHours(18))) && sh.End != null),
                x.Shifts.Count(sh => sh.Date > DateOnly.FromDateTime(DateTime.Now.AddDays(-30)) && sh.End != null)
                    ));

            return await response.ToListAsync(cancellationToken);
        }
    }
}
