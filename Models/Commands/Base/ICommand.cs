using API.Utility.Result;
using MediatR;

namespace API.Models.Commands.Base
{
    /// <summary>
    /// Команда для запроса
    /// </summary>
    public interface ICommand : IRequest<Result> { }
    /// <summary>
    /// Команда для запроса <typeparamref name="T"/>
    /// </summary>
    public interface ICommand<T> : IRequest<Result<T>> { }
}
