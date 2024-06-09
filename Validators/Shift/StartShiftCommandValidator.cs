using API.Data.Context;
using API.Models.Commands;
using API.Utility.Constants;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace API.Validators.Shift
{
    /// <summary>
    /// Класс для валидации команды <see cref="StartShiftCommand"/>
    /// </summary>
    public class StartShiftCommandValidator : AbstractValidator<StartShiftCommand>
    {
        /// <summary>
        /// Конструктор валидатора с его правилами
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public StartShiftCommandValidator(DataContext context)
        {
            #region External Validation
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ContextConstants.IdEmptyMessage)
                .CustomAsync(async (prop, vcontext, token) =>
                {
                    if (!await context.Employees.AnyAsync(x => x.Id == prop, token))
                    {
                        vcontext.AddFailure(ContextConstants.EmployeeNotFound);
                    }
                    else
                    {
                        if (await context.Shifts
                                .AnyAsync(x => x.EmployeeId == prop && x.End == null, token))
                        {
                            vcontext
                                .AddFailure(ContextConstants.ShiftAlrearyStarted);
                        }
                    }
                });
            #endregion
        }
    }
}
