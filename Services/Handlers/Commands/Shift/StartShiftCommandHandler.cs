using API.Data.Repositories.Interfaces;
using API.Models.Commands;
using API.Services.Handlers.Commands.Base;
using API.Utility.Result;

namespace API.Services.Handlers.Commands.Shift
{
    /// <summary>
    /// Класс-обработчик команды на начало смены сотрудника
    /// </summary>
    public class StartShiftCommandHandler : ICommandHandler<StartShiftCommand>
    {
        /// <summary>
        /// Репозиторий смен, <see cref="Models.Entity.Shift"/>
        /// </summary>
        private readonly IShiftRepository _repository;
        /// <summary>
        /// Конструктор обработчика
        /// </summary>
        /// <param name="repository">Репозиторий смен, <see cref="Models.Entity.Shift"/></param>
        public StartShiftCommandHandler(IShiftRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Метод-обработчик команды на начало смены сотрудника
        /// </summary>
        /// <param name="request">Модель-команда</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns><see cref="Result"/> и необходимый тип описанный в команде <see cref="StartShiftCommand"/></returns>
        public async Task<Result> Handle(StartShiftCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddItem(new Models.Entity.Shift()
            {
                Date = request.Date,
                EmployeeId = request.Id,
                Start = request.Time,
            }, cancellationToken);
            return Result.Success();
        }
    }
}
