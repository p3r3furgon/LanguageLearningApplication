using Learning.Application.Dtos.ResponseDtos;
using MediatR;

namespace Learning.Application.UseCases.DomainAreasUseCases.Queries.GetDomainAreas
{
    public record GetDomainAreasQuery : IRequest<GetDomainAreasResponse>;

    public record GetDomainAreasResponse(List<DomainAreaResponseDto> DomainAreasDto);
}
