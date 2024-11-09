using Learning.Application.Dtos.RequestDtos;
using Learning.Application.UseCases.QuestionsUseCases.Commands.AddBuildSentanceQuestion;
using Learning.Application.UseCases.QuestionsUseCases.Commands.AddMediaQuestion;
using Learning.Application.UseCases.QuestionsUseCases.Commands.AddTranslateQuestion;
using Learning.Application.UseCases.QuestionsUseCases.Commands.DeleteBuildSentanceQuestion;
using Learning.Application.UseCases.QuestionsUseCases.Commands.DeleteMediaQuestion;
using Learning.Application.UseCases.QuestionsUseCases.Commands.DeleteTranslateQuestion;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Learning.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("media")]
        public async Task<IActionResult> AddMediaQuestion([FromForm] MediaQuestionRequestDto mediaQuestionDto)
        {
            var response = await _mediator.Send(new AddMediaQuestionCommand(mediaQuestionDto));
            return StatusCode(StatusCodes.Status201Created, response);
        }


        [HttpDelete("media/{id}")]
        public async Task<IActionResult> DeleteMediaQuestion(int id)
        {
            var response = await _mediator.Send(new DeleteMediaQuestionCommand(id));
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPost("translate")]
        public async Task<IActionResult> AddTranslateQuestion(TranslateQuestionRequestDto translateQuestionDto)
        {
            var response = await _mediator.Send(new AddTranslateQuestionCommand(translateQuestionDto));
            return StatusCode(StatusCodes.Status201Created, response);
        }


        [HttpDelete("translate/{id}")]
        public async Task<IActionResult> DeleteTranslateQuestion(int id)
        {
            var response = await _mediator.Send(new DeleteTranslateQuestionCommand(id));
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPost("build_sentance")]
        public async Task<IActionResult> AddBuildSentanceQuestion([FromForm] BuildSentanceQuestionRequestDto buildSentanceQuestionDto)
        {
            var response = await _mediator.Send(new AddBuildSentanceQuestionCommand(buildSentanceQuestionDto));
            return StatusCode(StatusCodes.Status201Created, response);
        }


        [HttpDelete("build_sentance/{id}")]
        public async Task<IActionResult> DeleteBuildSentanceQuestion(int id)
        {
            var response = await _mediator.Send(new DeleteBuildSentanceQuestionCommand(id));
            return StatusCode(StatusCodes.Status201Created, response);
        }
    }
}
