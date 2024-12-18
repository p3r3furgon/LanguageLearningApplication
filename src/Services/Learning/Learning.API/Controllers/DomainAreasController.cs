﻿using Learning.Application.Dtos.RequestDtos;
using Learning.Application.UseCases.ChaptersUseCases.Queries.GetChapterById;
using Learning.Application.UseCases.DomainAreasUseCases.Queries.GetDomainAreaById;
using Learning.Application.UseCases.DomainAreasUseCases.Queries.GetDomainAreas;
using Learning.Application.UseCases.DomainAreaUseCases.Commands.AddDomainArea;
using Learning.Application.UseCases.DomainAreaUseCases.Commands.DeleteDomainArea;
using Learning.Application.UseCases.TestsUseCases.Queries.GetTestsByDomainAreaId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Learning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainAreasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DomainAreasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetDomainAreas()
        {
            var response = await _mediator.Send(new GetDomainAreasQuery());
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDomainAreaById(int id)
        {
            var response = await _mediator.Send(new GetDomainAreaByIdQuery(id));
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpGet("{id}/tests")]
        public async Task<IActionResult> GetTestsByDomainAreaId(int id)
        {
            var response = await _mediator.Send(new GetTestsByDomainAreaIdQuery(id));
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        [Authorize(Policy = "SuperAdmin")]
        public async Task<IActionResult> AddDomainArea(DomainAreaRequestDto domainAreaDto)
        {
            var response = await _mediator.Send(new AddDomainAreaCommand(domainAreaDto));
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
        [Authorize(Policy = "SuperAdmin")]
        public async Task<IActionResult> DeleteDomainArea(int id)
        {
            var response = await _mediator.Send(new DeleteDomainAreaCommand(id));
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
