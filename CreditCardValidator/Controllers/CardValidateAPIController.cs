using CreditCardValidator.Logics.Interface;
using CreditCardValidator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace CreditCardValidator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardValidateAPIController : ControllerBase
    {
        private readonly ICardValidateLogic _cardValidateLogic;

        public CardValidateAPIController(ICardValidateLogic cardValidateLogic)
        {
            _cardValidateLogic = cardValidateLogic;
        }

        [HttpPost]
        [Route("CheckCard")]
        public IActionResult CheckCard(CardRequet cardRequet)
        {
            var result = _cardValidateLogic.ValidateCard(cardRequet);
            return Ok(new { Type = result.CardType.ToString(), Status = result.Status });
        }
    }
}
