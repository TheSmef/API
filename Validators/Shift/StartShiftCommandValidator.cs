using API.Data.Context;
using API.Models.Commands;
using API.Utility.Constants;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace API.Validators.Shift
{
    public class StartShiftCommandValidator : AbstractValidator<StartShiftCommand>
    {
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
