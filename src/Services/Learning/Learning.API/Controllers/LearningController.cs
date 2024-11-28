using Learning.Application.UseCases.LearningUseCases.Commands.GenerateTest;
using Learning.Application.UseCases.LearningUseCases.Queries.GetLanguageCourseContent;
using Learning.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Learning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMinioService _minioService;
        public LearningController(IMediator mediator, IMinioService minioService)
        {
            _mediator = mediator;
            _minioService = minioService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetLanguageCourseContent()
        {
            var response = await _mediator.Send(new GetLanguageCourseContentQuery());
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet("test/{id}")]
        [Authorize]
        public async Task<IActionResult> GenerateTest(int id)
        {
            var response = await _mediator.Send(new GenerateTestCommand(id));
            return StatusCode(StatusCodes.Status200OK, response);
        }


        [HttpGet("download")]
        public async Task<IActionResult> DownloadFile(string bucketName, string fileName)
        {
            var fileBytes = await _minioService.GetBytes(bucketName, fileName);
            return File(fileBytes, "application/octet-stream", "йоу");
        }


    }
}
