using Learning.Domain.Models.Questions;
using MediatR;

namespace Learning.Application.UseCases.QuestionsUseCases.Queries.GetBuildSentanceQuestions
{
    public record GetBuildSentanceQuestionsQuery 
        : IRequest<GetBuildSentanceQuestionsResponse>;

    public record GetBuildSentanceQuestionsResponse(List<BuildSentanceQuestion> BuildSentanceQuestions);
}
