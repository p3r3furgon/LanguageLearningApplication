using Learning.Application.Dtos.RequestDtos;
using MediatR;

namespace Learning.Application.UseCases.ChaptersUseCases.Commands.AddChapter
{
    public record AddChapterCommand(ChapterRequestDto ChapterDto) 
        : IRequest<AddChapterResponse>;
    public record AddChapterResponse(bool IsSuccess, string Message);

}
