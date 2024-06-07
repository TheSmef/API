using FluentResults;
using MediatR;

namespace API.Models.Queries.Base
{
    public record IQuery<T> : IRequest<Result<T>>;
}
