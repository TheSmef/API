using API.Data.Repositories.Base;
using API.Data.Repositories.Interfaces;
using API.Models.Commands;
using API.Models.Entity;
using API.Models.Response;
using API.Services.Handlers.Commands.Base;
using API.Utility.Result;

namespace API.Services.Handlers.Commands.Employee
{
    /// <summary>
    /// Класс-обработчик команды на добавление сотрудника
    /// </summary>
    public class AddEmployeeCommandHandler : ICommandHandler<AddEmployeeCommand, EmployeeResponse>
    {
        /// <summary>
        /// Репозиторий сотрудников, <see cref="Models.Entity.Employee"/>
        /// </summary>
        private readonly IEmployeeRepository _repository;
        /// <summary>
        /// Конструктор обработчика
        /// </summary>
        /// <param name="repository">Репозиторий сотрудников, <see cref="Models.Entity.Employee"/></param>
        public AddEmployeeCommandHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Метод-обработчик команды
        /// </summary>
        /// <param name="request">Модель-команда</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns><see cref="Result"/> и необходимый тип описанный в команде <see cref="AddEmployeeCommand"/></returns>
        public async Task<Result<EmployeeResponse>> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.AddItem(new Models.Entity.Employee()
            {
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
