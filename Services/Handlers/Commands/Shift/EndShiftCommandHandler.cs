using API.Data.Context;
using API.Data.Repositories.Interfaces;
using API.Models.Commands;
using API.Services.Handlers.Commands.Base;
using API.Utility.Result;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Handlers.Commands.Shift
{
    /// <summary>
    /// Класс-обработчик команды на окончания смены сотрудника
    /// </summary>
    public class EndShiftCommandHandler : ICommandHandler<EndShiftCommand>
    {
        /// <summary>
        /// Контекст базы данных
        /// </summary>
        private readonly DataContext _context;
        /// <summary>
        /// Конструктор класса-обработчика
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public EndShiftCommandHandler(DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Метод-обработчик команды на окончание смены сотрудника
        /// </summary>
        /// <param name="request">Модель-команда</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns><see cref="Result"/> и необходимый тип описанный в команде <see cref="EndShiftCommand"/></returns>
        public async Task<Result> Handle(EndShiftCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Shifts
                .FirstAsync(x => x.EmployeeId == request.Id && x.End == null, cancellationToken);
            item.End = request.Time;
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
