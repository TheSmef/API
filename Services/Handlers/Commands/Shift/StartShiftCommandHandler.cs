using API.Data.Repositories.Interfaces;
using API.Models.Commands;
using API.Services.Handlers.Commands.Base;
using FluentResults;

namespace API.Services.Handlers.Commands.Shift
{
    public class StartShiftCommandHandler : ICommandHandler<StartShiftCommand>
    {
        private readonly IShiftRepository _repository;

        public StartShiftCommandHandler(IShiftRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(StartShiftCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddItem(new Models.Entity.Shift()
            {
                Date = request.Date,
                EmployeeId = request.Id,
                Start = request.Time,
            }, cancellationToken);
            return Result.Ok();
        }
    }
}
