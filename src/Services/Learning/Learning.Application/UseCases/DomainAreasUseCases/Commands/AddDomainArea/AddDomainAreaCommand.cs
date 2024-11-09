using Learning.Application.Dtos.RequestDtos;
using MediatR;

namespace Learning.Application.UseCases.DomainAreaUseCases.Commands.AddDomainArea
{
    public record AddDomainAreaCommand(DomainAreaRequestDto DomainAreaDto)
        : IRequest<AddDomainAreaResponse>;

    public record AddDomainAreaResponse(bool IsSuccess, string Message);
}
