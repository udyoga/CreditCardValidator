using CreditCardValidator.Logics.Interface;
using CreditCardValidator.Models;
using CreditCardValidator.Utils;

namespace CreditCardValidator.Logics.Implementation
{
    public class CardValidateLogic : ICardValidateLogic
    {
        public (CardType CardType, bool Status) ValidateCard(CardRequet cardRequet)
        {
            List<int> numberArray = new List<int>();
            var cardType = CheckCardType(cardRequet.CardNumber, out numberArray);
            bool isValid = false;

            if (cardType != CardType.NotValid)
            {
                isValid = ValidateCardNumber(numberArray);
            }
            return (cardType, isValid);
        }

        private CardType CheckCardType(string cardNumber, out List<int> numberArray)
        {
            CardType cardType = CardType.NotValid;

            //--- Convert string number to digit list
            numberArray = cardNumber.ToArray().Select(a => int.Parse(a.ToString())).ToList();

            if (numberArray.Count > 0)
            {
                switch (numberArray.Count)
                {
                    case 15:
                        if (numberArray[0] == 3 && (numberArray[1] == 4 || numberArray[1] == 7))
                        {
                            cardType = CardType.AMEX;
                        }
                        break;
                    case 16:
                        if (numberArray[0] == 5 && numberArray[1] <= 5 && numberArray[1] > 0)
                        {
                            cardType = CardType.MasterCard;
                        }
                        else if (numberArray[0] == 6 && numberArray[1] == 0 && numberArray[2] == 1 && numberArray[3] == 1)
                        {
                            cardType = CardType.Discover;
                        }
                        else if (numberArray[0] == 4)
                        {
                            cardType = CardType.Visa;
                        }
                        break;
                    case 13:
                        if (numberArray[0] == 4)
                        {
                            cardType = CardType.Visa;
                        }
                        break;
                    default:
                        cardType = CardType.NotValid;
                        break;
                }
            }
            return cardType;
        }

        private bool ValidateCardNumber(List<int> numberArray)
        {
            int sum = 0;
            int x = 0;

            for (int i = numberArray.Count-1; i >= 0; i--)
            {
                int currentNumber = numberArray[i];
                if (x % 2 == 1)
                {
                    currentNumber = currentNumber * 2;
                }

                if (currentNumber > 9)
                {
                    sum += currentNumber.SumOfDigits();
                }
                else
                {
                    sum += currentNumber;
                }
                x++;
            }

            if (sum % 10 == 0)
                return true;

            return false;
        }
    }
}
