using MediatR;

namespace Learning.Application.UseCases.QuestionsUseCases.Commands.DeleteTranslateQuestion
{
    public record DeleteTranslateQuestionCommand(int Id)
        : IRequest<DeleteTranslateQuestionResponse>;
    public record DeleteTranslateQuestionResponse(bool IsSuccess, string Message);
}
