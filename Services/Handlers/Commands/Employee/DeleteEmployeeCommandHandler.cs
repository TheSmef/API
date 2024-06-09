using API.Data.Repositories.Interfaces;
using API.Models.Commands;
using API.Services.Handlers.Commands.Base;
using API.Utility.Result;

namespace API.Services.Handlers.Commands.Employee
{
    /// <summary>
    /// Класс-обработчик команды на удаление сотрудника
    /// </summary>
    public class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand>
    {
        /// <summary>
        /// Репозиторий сотрудников, <see cref="Models.Entity.Employee"/>
        /// </summary>
        private readonly IEmployeeRepository _repository;
        /// <summary>
        /// Конструктор обработчика
        /// </summary>
        /// <param name="repository">Репозиторий сотрудников, <see cref="Models.Entity.Employee"/></param>
        public DeleteEmployeeCommandHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Метод-обработчик команды
        /// </summary>
        /// <param name="request">Модель-команда</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns><see cref="Result"/></returns>
        public async Task<Result> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveItem(request.Id, cancellationToken);
            return Result.Success();
        }
    }
}
