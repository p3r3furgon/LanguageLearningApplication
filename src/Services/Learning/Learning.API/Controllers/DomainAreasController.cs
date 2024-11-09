﻿using Learning.Application.Dtos.RequestDtos;
using Learning.Application.UseCases.DomainAreaUseCases.Commands.AddDomainArea;
using Learning.Application.UseCases.DomainAreaUseCases.Commands.DeleteDomainArea;
using MediatR;
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

        [HttpPost]
        public async Task<IActionResult> AddDomainArea(DomainAreaRequestDto domainAreaDto)
        {
            var response = await _mediator.Send(new AddDomainAreaCommand(domainAreaDto));
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDomainArea(int id)
        {
            var response = await _mediator.Send(new DeleteDomainAreaCommand(id));
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}