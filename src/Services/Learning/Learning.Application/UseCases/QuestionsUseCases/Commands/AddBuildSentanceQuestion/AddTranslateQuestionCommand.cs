using Learning.Application.Dtos.RequestDtos;
using MediatR;

namespace Learning.Application.UseCases.QuestionsUseCases.Commands.AddBuildSentanceQuestion
{
    public record AddBuildSentanceQuestionCommand(BuildSentanceQuestionRequestDto BuildSentanceQuestionDto)
        : IRequest<AddBuildSentanceQuestionResponse>;
    public record AddBuildSentanceQuestionResponse(bool IsSuccess, string Message);
}
