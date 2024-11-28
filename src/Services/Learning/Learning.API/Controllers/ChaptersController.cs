using Learning.Application.Dtos.RequestDtos;
using Learning.Application.UseCases.ChaptersUseCases.Commands.AddChapter;
using Learning.Application.UseCases.ChaptersUseCases.Commands.DeleteChapter;
using Learning.Application.UseCases.ChaptersUseCases.Commands.UpdateChapter;
using Learning.Application.UseCases.ChaptersUseCases.Queries.GetChapterById;
using Learning.Application.UseCases.ChaptersUseCases.Queries.GetChapters;
using Learning.Application.UseCases.DomainAreasUseCases.Queries.GetDomainAreasByChapterId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        public async Task<IActionResult> GetChapters()
        {
            var response = await _mediator.Send(new GetChaptersQuery());
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChapterById(int id)
        {
            var response = await _mediator.Send(new GetChapterByIdQuery(id));
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpGet("{id}/domains")]
        public async Task<IActionResult> GetDomainsByChapterId(int id)
        {
            var response = await _mediator.Send(new GetDomainAreasByChapterIdQuery(id));
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        [Authorize(Policy = "SuperAdmin")]
        public async Task<IActionResult> AddChapter(ChapterRequestDto chapterDto)
        {
            var response = await _mediator.Send(new AddChapterCommand(chapterDto));
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "Admin")]
        [Authorize(Policy = "SuperAdmin")]
        public async Task<IActionResult> UpdateChapter(int id, ChapterRequestDto chapterDto)
        {
            var response = await _mediator.Send(new UpdateChapterCommand(id, chapterDto));
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
        [Authorize(Policy = "SuperAdmin")]
        public async Task<IActionResult> DeleteChapter(int id)
        {
            var response = await _mediator.Send(new DeleteChapterCommand(id));
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
