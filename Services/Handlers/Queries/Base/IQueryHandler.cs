using API.Models.Queries.Base;
using FluentResults;
using MediatR;

namespace API.Services.Handlers.Queries.Base
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
     where TQuery : IQuery<TResponse>;
}
