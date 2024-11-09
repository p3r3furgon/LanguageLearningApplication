using Learning.Application.Dtos.RequestDtos;
using MediatR;

namespace Learning.Application.UseCases.QuestionsUseCases.Commands.AddTranslateQuestion
{
    public record AddTranslateQuestionCommand(TranslateQuestionRequestDto TranslateQuestionDto)
        : IRequest<AddTranslateQuestionResponse>;
    public record AddTranslateQuestionResponse(bool IsSuccess, string Message);
}
