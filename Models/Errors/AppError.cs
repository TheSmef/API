using API.Models.Errors.Base;
using API.Models.Errors.Response;
using FluentResults;

namespace API.Models.Errors
{
    public class AppError : Error, IErrorHandler
    {
        public List<string> Errors { get; set; } = new();
        public AppError(string message) : base(message) { }
        public AppError(List<string> Errors, string message) : base(message)
        {
            this.Errors = Errors;
        }

        public ErrorResponse MapToResponse()
        {
            return new ErrorResponse()
            {
                Message = this.Message,
                Errors = this.Errors,
                Code = 400
            };
        }
    }
}
