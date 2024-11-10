using Learning.Domain.Models.Questions;
using MediatR;

namespace Learning.Application.UseCases.QuestionsUseCases.Queries.GetBuildSentanceQuestionById
{
    public record GetBuildSentanceQuestionByIdQuery(int Id)
        : IRequest<GetBuildSentanceQuestionByIdResponse>;

    public record GetBuildSentanceQuestionByIdResponse(BuildSentanceQuestion? Question);

}
