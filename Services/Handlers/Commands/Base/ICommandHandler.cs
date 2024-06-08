using API.Models.Commands.Base;
using FluentResults;
using MediatR;

namespace API.Services.Handlers.Commands.Base
{
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
        where TCommand : ICommand<TResponse>;

    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result>
        where TCommand : ICommand;
}
