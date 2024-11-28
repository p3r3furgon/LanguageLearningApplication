using Learning.Application.Dtos.ResponseDtos;
using Learning.Domain.Models.Questions;
using MediatR;

namespace Learning.Application.UseCases.LearningUseCases.Commands.GenerateTest
{
    public record GenerateTestCommand(int TestId) 
        : IRequest<GenerateTestResponse>;
    public record GenerateTestResponse(List<RandomQuestionResponseDto> Questions);
}
