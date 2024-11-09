using MediatR;

namespace Learning.Application.UseCases.QuestionsUseCases.Commands.DeleteMediaQuestion
{
    public record DeleteMediaQuestionCommand(int Id) 
        : IRequest<DeleteMediaQuestionResponse>;
    public record DeleteMediaQuestionResponse(bool IsSuccess, string Message);
}
