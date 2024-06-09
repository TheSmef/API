using API.Models.Queries.Base;
using API.Utility.Result;
using MediatR;

namespace API.Services.Handlers.Queries.Base
{
    /// <summary>
    /// Интерфейс-обработчик запросов
    /// </summary>
    /// <typeparam name="TQuery">Запрос</typeparam>
    /// <typeparam name="TResponse">Ответ</typeparam>
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
     where TQuery : IQuery<TResponse>;
}
