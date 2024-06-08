using API.Data.Context;
using API.Models.Commands;
using API.Utility.Constants;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace API.Validators.Shift
{
    public class EndShiftCommandValidator : AbstractValidator<EndShiftCommand>
    {
        public EndShiftCommandValidator(DataContext context)
        {
            #region Internal Validation
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ContextConstants.IdEmptyMessage);
            #endregion
            #region External Validation
            RuleFor(x => x)
                .CustomAsync(async (prop, vcontext, token) =>
                {
                    if (!await context.Employees.AnyAsync(x => x.Id == prop.Id, token))
                    {
                        vcontext.AddFailure(ContextConstants.EmployeeNotFound);
                    }
                    else
                    {
                        var shift = await context.Shifts.AsNoTracking()
                                .FirstOrDefaultAsync(x => x.EmployeeId == prop.Id && x.End == null, token);
                        if (shift == null)
                        {
                            vcontext.AddFailure(ContextConstants.ShiftAlrearyEnded);
                        }
                        else
                        {
                            if (shift.Start >= prop.Time)
                                vcontext.AddFailure(ContextConstants.StartGreaterThanEnd);
                        }
                    } 
                });
            #endregion
        }
    }
}
