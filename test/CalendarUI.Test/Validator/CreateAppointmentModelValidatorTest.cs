using CalendarUI.Validators;
using FluentValidation.TestHelper;
using System;
using Xunit;

namespace CalendarUI.Test.Validator
{
    public class CreateAppointmentModelValidatorTest
    {
        private readonly CreateAppointmentModelValidator _testee;

        public CreateAppointmentModelValidatorTest()
        {
            _testee = new CreateAppointmentModelValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("a")]
        public void Description_WhenShorterThanTwoCharacter_ShouldHaveValidationError(string description)
        {
            _testee.ShouldHaveValidationErrorFor(x => x.Description, description)
                .WithErrorMessage("The description must be at least 2 character long");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("a")]
        public void Organizer_WhenShorterThanTwoCharacter_ShouldHaveValidationError(string organizer)
        {
            _testee.ShouldHaveValidationErrorFor(x => x.Organizer, organizer)
                .WithErrorMessage("The organizer must be at least 2 character long");
        }

        [Fact]
        public void Description_WhenLongerThanTwoCharacter_ShouldNotHaveValidationError()
        {
            _testee.ShouldNotHaveValidationErrorFor(x => x.Description, "Ab");
        }

        [Fact]
        public void Organizer_WhenLongerThanTwoCharacter_ShouldNotHaveValidationError()
        {
            _testee.ShouldNotHaveValidationErrorFor(x => x.Organizer, "Ab");
        }
    }
}
