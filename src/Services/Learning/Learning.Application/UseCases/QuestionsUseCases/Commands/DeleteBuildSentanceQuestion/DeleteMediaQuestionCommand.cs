using MediatR;

namespace Learning.Application.UseCases.QuestionsUseCases.Commands.DeleteBuildSentanceQuestion
{
    public record DeleteBuildSentanceQuestionCommand(int Id)
        : IRequest<DeleteBuildSentanceQuestionResponse>;
    public record DeleteBuildSentanceQuestionResponse(bool IsSuccess, string Message);
}
