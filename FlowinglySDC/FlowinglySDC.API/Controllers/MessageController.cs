using FlowinglySDC.API.Models;
using FlowinglySDC.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlowinglySDC.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly UserMessageValidator _validator;
        private readonly CostCalculator _costCalculator;
        private readonly JsonParser _jsonParser;

        public MessageController(
            UserMessageValidator validator,
            CostCalculator costCalculator,
            JsonParser jsonParser)
        {
            _validator = validator;
            _costCalculator = costCalculator;
            _jsonParser = jsonParser;
        }

        [HttpPost("ValidateUserMessage")]
        public ActionResult<UserMessageValidationResult> ValidateUserMessage([FromBody] string message)
        {
            var result = _validator.Validate(message);
            return Ok(result);
        }

        [HttpPost("CalculateUserMessageCosts")]
        public ActionResult<string> CalculateUserMessageCosts([FromBody] string message)
        {
            var validationResult = _validator.Validate(message);
            var calculationResult = _costCalculator.CalculateCosts(validationResult);
            var json = _jsonParser.ParseUserMessage(validationResult, calculationResult, message);

            return Content(json, "application/json");
        }
    }
}
