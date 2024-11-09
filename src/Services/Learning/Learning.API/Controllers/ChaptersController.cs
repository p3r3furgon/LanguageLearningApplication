using Learning.Application.Dtos.RequestDtos;
using Learning.Application.UseCases.ChaptersUseCases.Commands.AddChapter;
using Learning.Application.UseCases.ChaptersUseCases.Commands.DeleteChapter;
using Learning.Application.UseCases.ChaptersUseCases.Commands.UpdateChapter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Learning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChaptersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChaptersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddChapter(ChapterRequestDto chapterDto)
        {
            var response = await _mediator.Send(new AddChapterCommand(chapterDto));
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChapter(int id, ChapterRequestDto chapterDto)
        {
            var response = await _mediator.Send(new UpdateChapterCommand(id, chapterDto));
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChapter(int id)
        {
            var response = await _mediator.Send(new DeleteChapterCommand(id));
            return StatusCode(StatusCodes.Status201Created, response);
        }
    }
}
