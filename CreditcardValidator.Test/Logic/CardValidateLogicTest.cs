using CreditCardValidator.Logics.Implementation;
using CreditCardValidator.Models;
using CreditCardValidator.Validators;
using Xunit;

namespace CreditcardValidator.Test.Logic
{
    public class CardValidateLogicTest
    {
        [Fact]
        public void Card_Input_Validation_Test()
        {
            var validator = new CardInputValidator();

            Assert.False(validator.Validate(new CardRequet()).IsValid);

            Assert.False(validator.Validate(new CardRequet { CardNumber = "xyzghfghfgh" }).IsValid);

            Assert.False(validator.Validate(new CardRequet { CardNumber = "1212121abc" }).IsValid);

            Assert.False(validator.Validate(new CardRequet { CardNumber = "5105 1051 0510 5106" }).IsValid);

            Assert.True(validator.Validate(new CardRequet { CardNumber = "33123123123" }).IsValid);

            Assert.True(validator.Validate(new CardRequet { CardNumber = "4111111111111111" }).IsValid);           
        }

        [Fact]
        public void Card_Validate_Test()
        {           
            var validator = new CardValidateLogic();

            var input1 = validator.ValidateCard(new CardRequet { CardNumber = "4111111111111111" });
            var input2 = validator.ValidateCard(new CardRequet { CardNumber = "4111111111111" });
            var input3 = validator.ValidateCard(new CardRequet { CardNumber = "4012888888881881" });
            var input4 = validator.ValidateCard(new CardRequet { CardNumber = "378282246310005" });
            var input5 = validator.ValidateCard(new CardRequet { CardNumber = "6011111111111117" });
            var input6 = validator.ValidateCard(new CardRequet { CardNumber = "5105105105105100" });
            var input7 = validator.ValidateCard(new CardRequet { CardNumber = "9111111111111111" });

            Assert.True(input1.Status);
            Assert.True(input1.CardType == CardType.Visa);

            Assert.False(input2.Status);
            Assert.True(input2.CardType == CardType.Visa);

            Assert.True(input3.Status);
            Assert.True(input3.CardType == CardType.Visa);

            Assert.True(input4.Status);
            Assert.True(input4.CardType == CardType.AMEX);

            Assert.True(input5.Status);
            Assert.True(input5.CardType == CardType.Discover);

            Assert.True(input6.Status);
            Assert.True(input6.CardType == CardType.MasterCard);

            Assert.False(input7.Status);
            Assert.True(input7.CardType == CardType.NotValid);
        }
    }
}