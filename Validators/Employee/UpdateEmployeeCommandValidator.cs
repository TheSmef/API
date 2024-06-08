using API.Data.Repositories.Interfaces;
using API.Models.Commands;
using API.Utility.Constants;
using FluentValidation;

namespace API.Validators.Employee
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmplyeeCommand>
    {
        public UpdateEmployeeCommandValidator(IEmployeeRepository repository)
        {
            #region Internal Validation
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage(ContextConstants.FirstNameEmptyMessage)
                .Length(3, 120).WithMessage(ContextConstants.FirstNameLengthMessage)
                .Matches("\"^[а-яА-Яa-zA-Z]+$\"")
                .WithMessage(ContextConstants.FirstNameRegexMessage);
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage(ContextConstants.LastNameEmptyMessage)
                .Length(3, 120).WithMessage(ContextConstants.LastNameLengthMessage)
                .Matches("\"^[а-яА-Яa-zA-Z]+$\"")
                .WithMessage(ContextConstants.LastNameRegexMessage);
            RuleFor(x => x.FirstName).Length(3, 120)
                .When(s => !string.IsNullOrEmpty(s.FirstName))
                .WithMessage(ContextConstants.MiddleNameLengthMessage)
                .Matches("\"^[а-яА-Яa-zA-Z]+$\"")
                .When(s => !string.IsNullOrEmpty(s.FirstName))
                .WithMessage(ContextConstants.MiddleNameRegexMessage);

            RuleFor(x => x.Post).NotNull()
                .WithMessage(ContextConstants.PostEmptyMessage);
            #endregion
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
