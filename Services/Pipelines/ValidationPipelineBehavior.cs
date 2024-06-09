using API.Models.Errors;
using API.Utility.Constants;
using API.Utility.Result;
using FluentValidation;
using MediatR;
using System.Data;

namespace API.Services.Pipelines
{
    /// <summary>
    /// Pipeline на валидацию входящих команд и запросов
    /// </summary>
    /// <typeparam name="TRequest">Запрос/Команда</typeparam>
    /// <typeparam name="TResponse">Ответ</typeparam>
    public class ValidationPipelineBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : Result
    {
        /// <summary>
        /// Список валидаторов
        /// </summary>
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        /// <summary>
        /// Конструктор Pipeline
        /// </summary>
        /// <param name="validators">Список валидаторов</param>
        public ValidationPipelineBehavior
            (IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        /// <summary>
        /// Метод-обработчик Pipeline валидации
        /// </summary>
        /// <param name="request">Запрос/Команда</param>
        /// <param name="next">Делегат следующего элемента в Pipeline</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Продолжает выполнение Pipeline и возвращает значение следующего делегата</returns>
        public async Task<TResponse> Handle(TRequest request
            , RequestHandlerDelegate<TResponse> next
            , CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var errors = new List<string>();
                foreach(var validator in _validators)
                {
                    errors.AddRange((await validator.ValidateAsync(request, cancellationToken)).Errors.Select(x => x.ErrorMessage));
                }
                if (errors.Any())
                {
                    return GetResponse<TResponse>(errors);
                }
            }
            return await next();
        }
        /// <summary>
        /// Метод построение ответа <see cref="Result"/>
        /// </summary>
        /// <typeparam name="T">Тип данных ответа</typeparam>
        /// <param name="errors">Ошибки валидации</param>
        /// <returns><typeparamref name="T"/> ответ под запрос</returns>
        private static T GetResponse<T>(List<string> errors)
            where T : Result
        {
            if (typeof(TResponse) == typeof(Result))
            {
                return (Result.Failure(new Error(errors, ContextConstants.ValidationError)) as T)!;
            }
            var result = typeof(Result<>)
                .GetGenericTypeDefinition()
                .MakeGenericType(typeof(TResponse).GenericTypeArguments[0])
                .GetMethod(nameof(Result.Failure))!
                .Invoke(null, [new Error(errors, ContextConstants.ValidationError)]);

            return (T)result!;
        }
    }
}
