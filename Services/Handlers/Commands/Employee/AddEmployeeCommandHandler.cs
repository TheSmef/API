using API.Data.Repositories.Base;
using API.Data.Repositories.Interfaces;
using API.Models.Commands;
using API.Models.Response;
using API.Services.Handlers.Commands.Base;
using FluentResults;

namespace API.Services.Handlers.Commands.Employee
{
    public class AddEmployeeCommandHandler : ICommandHandler<AddEmployeeCommand, EmployeeResponse>
    {
        private readonly IEmployeeRepository _repository;

        public AddEmployeeCommandHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<EmployeeResponse>> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.AddItem(new Models.Entity.Employee()
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                Post = request.Post,
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
