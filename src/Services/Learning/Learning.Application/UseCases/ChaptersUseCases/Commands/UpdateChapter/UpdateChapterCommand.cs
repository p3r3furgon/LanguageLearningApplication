using Learning.Application.Dtos.RequestDtos;
using MediatR;

namespace Learning.Application.UseCases.ChaptersUseCases.Commands.UpdateChapter
{
    public record UpdateChapterCommand(int Id, ChapterRequestDto ChapterDto) 
        : IRequest<UpdateChapterResponse>;
    public record UpdateChapterResponse(bool IsSuccess, string Message);

}
