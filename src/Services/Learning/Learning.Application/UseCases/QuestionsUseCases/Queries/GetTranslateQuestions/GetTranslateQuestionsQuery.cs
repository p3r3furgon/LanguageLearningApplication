using Learning.Domain.Models.Questions;
using MediatR;

namespace Learning.Application.UseCases.QuestionsUseCases.Queries.GetTranslateQuestions
{
    public record GetTranslateQuestionsQuery() 
        : IRequest<GetTranslateQuestionsResponse>;

    public record GetTranslateQuestionsResponse(List<TranslateQuestion> TranslateQuestions);
}
