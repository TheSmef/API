using API.Data.Repositories.Interfaces;
using API.Models.Commands;
using API.Services.Handlers.Commands.Base;
using FluentResults;

namespace API.Services.Handlers.Commands.Employee
{
    public class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand>
    {
        private readonly IEmployeeRepository _repository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveItem(request.Id, cancellationToken);
            return Result.Ok();
        }
    }
}
