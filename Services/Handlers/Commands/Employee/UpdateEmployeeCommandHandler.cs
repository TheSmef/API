using API.Data.Repositories.Interfaces;
using API.Models.Commands;
using API.Models.Entity;
using API.Models.Response;
using API.Services.Handlers.Commands.Base;
using API.Utility.Result;

namespace API.Services.Handlers.Commands.Employee
{
    /// <summary>
    /// Класс-обработчик команды на изменение данных сотрудника
    /// </summary>
    public class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand, EmployeeResponse>
    {
        /// <summary>
        /// Репозиторий сотрудников, <see cref="Models.Entity.Employee"/>
        /// </summary>
        private readonly IEmployeeRepository _repository;
        /// <summary>
        /// Конструктор обработчика
        /// </summary>
        /// <param name="repository">Репозиторий сотрудников, <see cref="Models.Entity.Employee"/></param>
        public UpdateEmployeeCommandHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Метод-обработчик команды
        /// </summary>
        /// <param name="request">Модель-запрос</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns><see cref="Result"/> и необходимый тип описанный в команде <see cref="UpdateEmployeeCommand"/></returns>
        public async Task<Result<EmployeeResponse>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.UpdateItem(new Models.Entity.Employee()
            {
                Id = request.Id,
                LastName = request.LastName,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                Post = (PostEnum)request.Post!,
            }, cancellationToken);

            return new EmployeeResponse(
                item.Id,
                item.LastName,
                item.FirstName,
                item.MiddleName,
                item.Post
                );
        }
    }
}
