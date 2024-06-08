using API.Data.Context;
using API.Data.Repositories.Interfaces;
using API.Models.Commands;
using API.Services.Handlers.Commands.Base;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Handlers.Commands.Shift
{
    public class EndShiftCommandHandler : ICommandHandler<EndShiftCommand>
    {
        private readonly DataContext _context;

        public EndShiftCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(EndShiftCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Shifts
                .FirstAsync(x => x.EmployeeId == request.Id && x.End == null, cancellationToken);
            item.End = request.Time;
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}
