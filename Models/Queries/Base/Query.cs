using API.Utility.Result;
using MediatR;

namespace API.Models.Queries.Base
{
    /// <summary>
    /// Интерфейс запроса для получения данных
    /// </summary>
    /// <typeparam name="T">Возвращаемый запросом тип</typeparam>
    public interface IQuery<T> : IRequest<Result<T>>;
}
