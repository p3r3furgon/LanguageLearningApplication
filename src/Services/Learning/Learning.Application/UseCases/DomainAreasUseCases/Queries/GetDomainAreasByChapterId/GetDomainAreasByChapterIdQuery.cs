using Learning.Application.Dtos.ResponseDtos;
using MediatR;

namespace Learning.Application.UseCases.DomainAreasUseCases.Queries.GetDomainAreasByChapterId
{
    public record GetDomainAreasByChapterIdQuery(int ChapterId) : IRequest<GetDomainAreasByChapterIdResponse>;

    public record GetDomainAreasByChapterIdResponse(List<DomainAreaResponseDto> DomainAreasDto);
}
