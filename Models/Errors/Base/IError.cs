using API.Models.Errors.Response;
using FluentResults;

namespace API.Models.Errors.Base
{
    public interface IErrorHandler : IError
    {
        public ErrorResponse MapToResponse();
    }
}
