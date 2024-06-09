using API.Data.Repositories.Interfaces;
using API.Models.Commands;
using API.Utility.Constants;
using FluentValidation;

namespace API.Validators.Employee
{
    /// <summary>
    /// Класс для валидации команды <see cref="DeleteEmployeeCommand"/>
    /// </summary>
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        /// <summary>
        /// Конструктор валидатора с его правилами
        /// </summary>
        /// <param name="repository">Репозиторий сотрудников <see cref="Models.Entity.Employee"/></param>
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
