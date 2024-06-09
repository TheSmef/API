using API.Models.Commands.Base;
using API.Utility.Result;
using MediatR;

namespace API.Services.Handlers.Commands.Base
{
    /// <summary>
    /// Интерфейс обработчика команды с ответом (значением)
    /// </summary>
    /// <typeparam name="TCommand">Команда</typeparam>
    /// <typeparam name="TResponse">Ответ</typeparam>
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
        where TCommand : ICommand<TResponse>;
    /// <summary>
    /// Интерфейс обработчика команды без ответа
    /// </summary>
    /// <typeparam name="TCommand">Команда</typeparam>
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result>
        where TCommand : ICommand;
}
