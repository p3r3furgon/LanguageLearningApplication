using Learning.Application.Dtos.ResponseDtos;
using MediatR;

namespace Learning.Application.UseCases.DomainAreasUseCases.Queries.GetDomainAreaById
{
    public record GetDomainAreaByIdQuery(int Id)
        : IRequest<GetDomainAreaByIdResponse>;

    public record GetDomainAreaByIdResponse(DomainAreaResponseDto DomainAreaDto);
}