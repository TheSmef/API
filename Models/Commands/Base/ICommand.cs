using FluentResults;
using MediatR;

namespace API.Models.Commands.Base
{
    public interface ICommand : IRequest<Result> { }

    public interface ICommand<T> : IRequest<Result<T>> { }
}
