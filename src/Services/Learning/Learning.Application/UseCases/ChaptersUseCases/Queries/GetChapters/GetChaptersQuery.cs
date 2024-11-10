using Learning.Application.Dtos.ResponseDtos;
using MediatR;

namespace Learning.Application.UseCases.ChaptersUseCases.Queries.GetChapters
{
    public record GetChaptersQuery : IRequest<GetChaptersResponse>;

    public record GetChaptersResponse(List<ChapterResponseDto> ChaptersDto);

}
