using API.Models.Errors.Response;
using API.Utility.Constants;
using Microsoft.AspNetCore.Mvc;

namespace API.Utility.Errors
{
    /// <summary>
    /// Статический класс для обработки ошибок Middleware Asp.Net
    /// </summary>
    public static class ErrorResponceHandler
    {
        /// <summary>
        /// Метод перевода ошибок Middleware в обшую модель ошибки
        /// </summary>
        /// <param name="context">Контекст действия</param>
        /// <returns>BadRequest с общей моделей ошибок</returns>
        public static IActionResult GenerateErrorResponce(ActionContext context)
        {
            var error = new ErrorResponse
            {
                Code = StatusCodes.Status400BadRequest,
                Message = ContextConstants.ValidationError,
            };
            var errors = context.ModelState.ToList();
            foreach (var errorItem in errors)
            {
                if (errorItem.Value != null)
                    error.Errors.AddRange(errorItem.Value.Errors.Select(x => x.ErrorMessage));
            }
            return new BadRequestObjectResult(error);
        }
    }
}
