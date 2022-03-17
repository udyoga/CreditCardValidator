using CreditCardValidator.Models;
using FluentValidation;

namespace CreditCardValidator.Validators
{
    public class CardInputValidator : AbstractValidator<CardRequet>
    {
        public CardInputValidator()
        {
            RuleFor(x => x.CardNumber).NotNull().NotEmpty();
            RuleFor(x => x.CardNumber).Length(0, 16);
            RuleFor(x => x.CardNumber).Matches("^[0-9]+$").WithMessage("Should contains only numbers");
        }
    }
}
