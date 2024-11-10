using Learning.Application.Dtos.RequestDtos;
using Learning.Application.UseCases.TestsUseCases.Commands.AddTest;
using Learning.Application.UseCases.TestsUseCases.Commands.DeleteTest;
using Learning.Application.UseCases.TestsUseCases.Queries.GetTestById;
using Learning.Application.UseCases.TestsUseCases.Queries.GetTests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Learning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTests()
        {
            var response = await _mediator.Send(new GetTestsQuery());
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestById(int id)
        {
            var response = await _mediator.Send(new GetTestByIdQuery(id));
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPost]
        public async Task<IActionResult> AddTest(TestRequestDto testDto)
        {
            var response = await _mediator.Send(new AddTestCommand(testDto));
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest(int id)
        {
            var response = await _mediator.Send(new DeleteTestCommand(id));
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
