using CalendarUI.Models;
using FluentValidation;
using System;

namespace CalendarUI.Validators
{
    public class UpdateAppointmentModelValidator : AbstractValidator<UpdateAppointmentModel>
    {
        public UpdateAppointmentModelValidator()
        {
            RuleFor(x => x.Description)
                .NotNull()
                .WithMessage("The description must be at least 2 character long");
            RuleFor(x => x.Description)
                .MinimumLength(2)
                .WithMessage("The description must be at least 2 character long");

            RuleFor(x => x.Organizer)
                .NotNull()
                .WithMessage("The organizer must be at least 2 character long");
            RuleFor(x => x.Organizer)
                .MinimumLength(2)
                .WithMessage("The organizer must be at least 2 character long");

            RuleFor(x => x.DateTime)
                .InclusiveBetween(DateTime.Now, DateTime.Now.AddDays(180).Date)
                .WithMessage("The date must not be longer than 180 days and can not be in before today");
        }
    }
}
