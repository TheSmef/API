using API.Models.Errors.Response;
using API.Utility.Constants;
using Microsoft.AspNetCore.Mvc;

namespace API.Utility.Errors
{
    public static class ErrorResponceHandler
    {
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
