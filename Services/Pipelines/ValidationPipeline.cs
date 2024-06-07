using API.Models.Errors;
using API.Utility.Constants;
using FluentResults;
using FluentValidation;
using MediatR;
using System.Data;

namespace API.Services.Pipelines
{
    public class ValidationPipeline<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : Result
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationPipeline
            (IEnumerable<IValidator<TRequest>> validators) => _validators = validators;


        public async Task<TResponse> Handle(TRequest request
            , RequestHandlerDelegate<TResponse> next
            , CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var errors = _validators.
                    Select(v => v.Validate(request))
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                if (errors != null)
                {
                    if (errors.Any())
                    {
                        return GetResponse(errors);
                    }
                }
            }
            return await next();
        }

        private TResponse GetResponse(List<string> errors)
        {
            if (typeof(TResponse) == typeof(Result))
            {
                return (Result.Fail(new AppError(errors, ContextConstants.ValidationError)) as TResponse)!;
            }

            var result = typeof(Result<>)
                .GetGenericTypeDefinition()
                .MakeGenericType(typeof(TResponse).GenericTypeArguments[0])
                .GetMethod(nameof(Result.Fail))!
                .Invoke(null, [errors, ContextConstants.ValidationError]);

            return (TResponse)result!;
        }
    }
}
