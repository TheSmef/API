using API.Data.Repositories.Interfaces;
using API.Models.Commands;
using API.Utility.Constants;
using FluentValidation;

namespace API.Validators.Employee
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator(IEmployeeRepository repository)
        {
            #region External Validation
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ContextConstants.IdEmptyMessage)
                .CustomAsync(async (prop, context, token) =>
                {
                    if (!await repository.Exists(prop, token))
                        context.AddFailure(ContextConstants.NotFound);
                });
            #endregion
        }
    }
}
