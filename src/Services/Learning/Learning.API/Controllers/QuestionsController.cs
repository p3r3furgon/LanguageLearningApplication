using Learning.Application.Dtos.RequestDtos;
using Learning.Application.UseCases.QuestionsUseCases.Commands.AddBuildSentanceQuestion;
using Learning.Application.UseCases.QuestionsUseCases.Commands.AddMediaQuestion;
using Learning.Application.UseCases.QuestionsUseCases.Commands.AddTranslateQuestion;
using Learning.Application.UseCases.QuestionsUseCases.Commands.DeleteBuildSentanceQuestion;
using Learning.Application.UseCases.QuestionsUseCases.Commands.DeleteMediaQuestion;
using Learning.Application.UseCases.QuestionsUseCases.Commands.DeleteTranslateQuestion;
using Learning.Application.UseCases.QuestionsUseCases.Queries.GetBuildSentanceQuestionById;
using Learning.Application.UseCases.QuestionsUseCases.Queries.GetBuildSentanceQuestions;
using Learning.Application.UseCases.QuestionsUseCases.Queries.GetMediaQuestionById;
using Learning.Application.UseCases.QuestionsUseCases.Queries.GetMediaQuestions;
using Learning.Application.UseCases.QuestionsUseCases.Queries.GetTranslateQuestionById;
using Learning.Application.UseCases.QuestionsUseCases.Queries.GetTranslateQuestions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("media")]
        [Authorize]
        public async Task<IActionResult> GetMediaQuestions()
        {
            var response = await _mediator.Send(new GetMediaQuestionsQuery());
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpGet("media/{id}")]
        [Authorize]
        public async Task<IActionResult> GetMediaQuestionById(int id)
        {
            var response = await _mediator.Send(new GetMediaQuestionByIdQuery(id));
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPost("media")]
        [Authorize(Policy = "Admin")]
        [Authorize(Policy = "SuperAdmin")]
        public async Task<IActionResult> AddMediaQuestion([FromForm] MediaQuestionRequestDto mediaQuestionDto)
        {
            var response = await _mediator.Send(new AddMediaQuestionCommand(mediaQuestionDto));
            return StatusCode(StatusCodes.Status201Created, response);
        }


        [HttpDelete("media/{id}")]
        [Authorize(Policy = "Admin")]
        [Authorize(Policy = "SuperAdmin")]
        public async Task<IActionResult> DeleteMediaQuestion(int id)
        {
            var response = await _mediator.Send(new DeleteMediaQuestionCommand(id));
            return StatusCode(StatusCodes.Status201Created, response);
        }


        [HttpGet("translate")]
        [Authorize]
        public async Task<IActionResult> GetTranslateQuestions()
        {
            var response = await _mediator.Send(new GetTranslateQuestionsQuery());
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpGet("translate/{id}")]
        [Authorize]
        public async Task<IActionResult> GetTranslateQuestionById(int id)
        {
            var response = await _mediator.Send(new GetTranslateQuestionByIdQuery(id));
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPost("translate")]
        [Authorize(Policy = "Admin")]
        [Authorize(Policy = "SuperAdmin")]
        public async Task<IActionResult> AddTranslateQuestion(TranslateQuestionRequestDto translateQuestionDto)
        {
            var response = await _mediator.Send(new AddTranslateQuestionCommand(translateQuestionDto));
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpDelete("translate/{id}")]
        [Authorize(Policy = "Admin")]
        [Authorize(Policy = "SuperAdmin")]
        public async Task<IActionResult> DeleteTranslateQuestion(int id)
        {
            var response = await _mediator.Send(new DeleteTranslateQuestionCommand(id));
            return StatusCode(StatusCodes.Status201Created, response);
        }


        [HttpGet("build_sentance")]
        [Authorize]
        public async Task<IActionResult> GetBuildSentanceQuestions()
        {
            var response = await _mediator.Send(new GetBuildSentanceQuestionsQuery());
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpGet("build_sentance/{id}")]
        [Authorize]
        public async Task<IActionResult> GetBuildSentanceQuestionById(int id)
        {
            var response = await _mediator.Send(new GetBuildSentanceQuestionByIdQuery(id));
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPost("build_sentance")]
        [Authorize(Policy = "Admin")]
        [Authorize(Policy = "SuperAdmin")]
        public async Task<IActionResult> AddBuildSentanceQuestion([FromForm] BuildSentanceQuestionRequestDto buildSentanceQuestionDto)
        {
            var response = await _mediator.Send(new AddBuildSentanceQuestionCommand(buildSentanceQuestionDto));
            return StatusCode(StatusCodes.Status201Created, response);
        }


        [HttpDelete("build_sentance/{id}")]
        [Authorize(Policy = "Admin")]
        [Authorize(Policy = "SuperAdmin")]
        public async Task<IActionResult> DeleteBuildSentanceQuestion(int id)
        {
            var response = await _mediator.Send(new DeleteBuildSentanceQuestionCommand(id));
            return StatusCode(StatusCodes.Status201Created, response);
        }
    }
}
