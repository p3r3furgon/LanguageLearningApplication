using Learning.Application.UseCases.QuestionsUseCases.Commands.AddMediaQuestion;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Learning.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LanguageLearningController : ControllerBase
    {

        private readonly ILogger<LanguageLearningController> _logger;
        private readonly IMediator _mediator;

        public LanguageLearningController(ILogger<LanguageLearningController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("questions")]
        public async Task<IActionResult> AddMediaQuestion([FromForm] AddMediaQuestionCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created, response);
        }
    }
}
