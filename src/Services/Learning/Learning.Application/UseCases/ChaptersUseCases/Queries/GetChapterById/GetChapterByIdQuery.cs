using Learning.Application.Dtos.ResponseDtos;
using MediatR;

namespace Learning.Application.UseCases.ChaptersUseCases.Queries.GetChapterById
{
    public record GetChapterByIdQuery(int Id) 
        : IRequest<GetChapterByIdResponse>;

    public record GetChapterByIdResponse(ChapterResponseDto ChapterDto);

}
