using MediatR;

namespace Learning.Application.UseCases.ChaptersUseCases.Commands.DeleteChapter
{
    public record DeleteChapterCommand(int Id) : IRequest<DeleteChapterResponse>;
    public record DeleteChapterResponse(bool IsSuccess, string Message);

}
