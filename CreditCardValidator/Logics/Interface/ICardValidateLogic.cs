using CreditCardValidator.Models;

namespace CreditCardValidator.Logics.Interface
{
    public interface ICardValidateLogic
    {
        (CardType CardType, bool Status) ValidateCard(CardRequet cardRequet);
    }
}
